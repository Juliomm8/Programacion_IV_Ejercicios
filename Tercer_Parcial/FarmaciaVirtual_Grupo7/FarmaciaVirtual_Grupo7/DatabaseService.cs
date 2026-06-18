using SQLite;

namespace FarmaciaVirtual_Grupo7;

public class DatabaseService
{
    private SQLiteAsyncConnection? _database;

    public async Task InitializeAsync()
    {
        if (_database is not null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "farmacia.db");
        _database = new SQLiteAsyncConnection(dbPath);

        await _database.CreateTableAsync<Medicina>();
        await _database.CreateTableAsync<Factura>();
        await _database.CreateTableAsync<DetalleFactura>();

        await SeedDataAsync();
    }

    private async Task SeedDataAsync()
    {
        var database = GetDatabase();

        var medicinasPredeterminadas = new List<Medicina>
        {
            new() { Nombre = "Paracetamol", Precio = 2.50m, Descripcion = "Analgésico", Stock = 100 },
            new() { Nombre = "Ibuprofeno", Precio = 3.75m, Descripcion = "Antiinflamatorio", Stock = 80 },
            new() { Nombre = "Amoxicilina", Precio = 8.90m, Descripcion = "Antibiótico", Stock = 50 },
            new() { Nombre = "Aspirina", Precio = 1.85m, Descripcion = "Analgésico", Stock = 120 },
            new() { Nombre = "Omeprazol", Precio = 5.60m, Descripcion = "Protector gástrico", Stock = 60 },
            new() { Nombre = "Loratadina", Precio = 4.25m, Descripcion = "Antihistamínico", Stock = 70 },
            new() { Nombre = "Diclofenaco", Precio = 6.40m, Descripcion = "Analgésico y antiinflamatorio", Stock = 90 }
        };

        var medicinasExistentes = await database.Table<Medicina>().ToListAsync();
        var nombresExistentes = medicinasExistentes
            .Select(m => m.Nombre)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var medicinasNuevas = medicinasPredeterminadas
            .Where(m => !nombresExistentes.Contains(m.Nombre))
            .ToList();

        if (medicinasNuevas.Count > 0)
            await database.InsertAllAsync(medicinasNuevas);
    }

    public async Task<List<Medicina>> GetMedicinasAsync()
    {
        await InitializeAsync();
        return await GetDatabase().Table<Medicina>().ToListAsync();
    }

    public async Task<int> SaveFacturaAsync(Factura factura, List<Medicina> medicinas)
    {
        await InitializeAsync();
        var database = GetDatabase();
        var medicinasSeleccionadas = medicinas
            .Where(m => m.Cantidad > 0)
            .ToList();

        if (medicinasSeleccionadas.Count == 0)
            throw new InvalidOperationException("No existen medicinas seleccionadas para guardar.");

        // La factura, sus detalles y el descuento de stock se guardan como una sola operación.
        // Si algo falla, SQLite revierte toda la compra y evita datos incompletos.
        await database.RunInTransactionAsync(connection =>
        {
            foreach (var medicinaSeleccionada in medicinasSeleccionadas)
            {
                var medicinaEnBase = connection.Find<Medicina>(medicinaSeleccionada.Id)
                    ?? throw new InvalidOperationException(
                        $"La medicina {medicinaSeleccionada.Nombre} ya no existe en el catálogo.");

                if (medicinaSeleccionada.Cantidad > medicinaEnBase.Stock)
                {
                    throw new InvalidOperationException(
                        $"Stock insuficiente para {medicinaEnBase.Nombre}. " +
                        $"Disponible: {medicinaEnBase.Stock}, solicitado: {medicinaSeleccionada.Cantidad}.");
                }
            }

            connection.Insert(factura);

            foreach (var medicinaSeleccionada in medicinasSeleccionadas)
            {
                var medicinaEnBase = connection.Find<Medicina>(medicinaSeleccionada.Id)!;

                var detalle = new DetalleFactura
                {
                    FacturaId = factura.Id,
                    MedicinaId = medicinaEnBase.Id,
                    NombreMedicina = medicinaEnBase.Nombre,
                    Precio = medicinaEnBase.Precio,
                    Cantidad = medicinaSeleccionada.Cantidad,
                    Subtotal = medicinaEnBase.Precio * medicinaSeleccionada.Cantidad
                };

                connection.Insert(detalle);

                // Se descuenta de manera permanente la cantidad comprada.
                medicinaEnBase.Stock -= medicinaSeleccionada.Cantidad;
                connection.Update(medicinaEnBase);
            }
        });

        return factura.Id;
    }

    public async Task<List<DetalleFactura>> GetDetalleFacturaAsync(int facturaId)
    {
        await InitializeAsync();
        return await GetDatabase().Table<DetalleFactura>()
            .Where(d => d.FacturaId == facturaId)
            .ToListAsync();
    }

    private SQLiteAsyncConnection GetDatabase()
    {
        return _database ?? throw new InvalidOperationException("La base de datos no ha sido inicializada.");
    }
}
