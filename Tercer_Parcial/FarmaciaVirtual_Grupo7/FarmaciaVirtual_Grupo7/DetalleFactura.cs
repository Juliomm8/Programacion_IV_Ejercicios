using SQLite;

namespace FarmaciaVirtual_Grupo7;

[Table("DetalleFacturas")]
public class DetalleFactura
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int FacturaId { get; set; }
    public int MedicinaId { get; set; }
    public string NombreMedicina { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}
