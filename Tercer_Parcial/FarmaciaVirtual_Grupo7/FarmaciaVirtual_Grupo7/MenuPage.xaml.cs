using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FarmaciaVirtual_Grupo7;

public partial class MenuPage : ContentPage
{
    private const decimal PorcentajeDescuento = 0.05m;
    private const decimal PorcentajeIva = 0.12m;
    private const decimal SubtotalMinimoDescuento = 50m;

    private readonly ObservableCollection<Medicina> _medicinas = new();
    private readonly DatabaseService _databaseService = new();

    public MenuPage()
    {
        InitializeComponent();
        MedicinasCollectionView.ItemsSource = _medicinas;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMedicinasAsync();
    }

    private async Task LoadMedicinasAsync()
    {
        try
        {
            var medicinas = await _databaseService.GetMedicinasAsync();

            foreach (var medicinaActual in _medicinas)
                medicinaActual.PropertyChanged -= OnMedicinaPropertyChanged;

            _medicinas.Clear();

            foreach (var medicina in medicinas)
            {
                medicina.PropertyChanged += OnMedicinaPropertyChanged;
                _medicinas.Add(medicina);
            }

            UpdateResumenVenta();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudieron cargar las medicinas: {ex.Message}", "OK");
        }
    }

    private void OnMedicinaPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Medicina.Subtotal))
            UpdateResumenVenta();
    }

    private void OnIncrementClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button || button.CommandParameter is not Medicina medicina)
            return;

        if (medicina.Cantidad < medicina.Stock)
            medicina.Cantidad++;
    }

    private void OnDecrementClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button || button.CommandParameter is not Medicina medicina)
            return;

        if (medicina.Cantidad > 0)
            medicina.Cantidad--;
    }

    private void OnDescuentoToggled(object? sender, ToggledEventArgs e)
    {
        UpdateResumenVenta();
    }

    private void UpdateResumenVenta()
    {
        var cantidadTotal = _medicinas.Sum(m => m.Cantidad);
        var productosDiferentes = _medicinas.Count(m => m.Cantidad > 0);
        var subtotal = Redondear(_medicinas.Sum(m => m.Subtotal));
        var cumpleCondicion = subtotal > SubtotalMinimoDescuento;

        lblCantidadTotal.Text = productosDiferentes == 0
            ? "0"
            : $"{cantidadTotal} en {productosDiferentes} producto(s)";

        switchDescuento.IsEnabled = cumpleCondicion;

        if (!cumpleCondicion && switchDescuento.IsToggled)
            switchDescuento.IsToggled = false;

        lblEstadoDescuento.Text = cumpleCondicion
            ? "Descuento disponible. Actívalo si deseas aplicarlo."
            : "Disponible cuando el subtotal supere $50.00";

        var descuento = CalcularDescuento(subtotal);
        var baseImponible = subtotal - descuento;
        var impuesto = Redondear(baseImponible * PorcentajeIva);
        var total = Redondear(baseImponible + impuesto);

        lblSubtotalVenta.Text = $"${subtotal:F2}";
        lblDescuentoVenta.Text = $"-${descuento:F2}";
        lblImpuestoVenta.Text = $"${impuesto:F2}";
        lblTotal.Text = $"${total:F2}";
    }

    private decimal CalcularDescuento(decimal subtotal)
    {
        if (!switchDescuento.IsToggled || subtotal <= SubtotalMinimoDescuento)
            return 0m;

        return Redondear(subtotal * PorcentajeDescuento);
    }

    private async void OnGenerarFacturaClicked(object? sender, EventArgs e)
    {
        var medicinasSeleccionadas = _medicinas
            .Where(m => m.Cantidad > 0)
            .ToList();

        if (medicinasSeleccionadas.Count == 0)
        {
            await DisplayAlert("Error", "Seleccione al menos una medicina", "OK");
            return;
        }

        var subtotal = Redondear(medicinasSeleccionadas.Sum(m => m.Subtotal));
        var descuento = CalcularDescuento(subtotal);
        var baseImponible = subtotal - descuento;
        var impuesto = Redondear(baseImponible * PorcentajeIva);
        var total = Redondear(baseImponible + impuesto);

        var factura = new Factura
        {
            NumeroFactura = $"FAC-{DateTime.Now:yyyyMMddHHmmss}",
            Fecha = DateTime.Now,
            Subtotal = subtotal,
            Descuento = descuento,
            Impuesto = impuesto,
            Total = total
        };

        btnGenerarFactura.IsEnabled = false;

        try
        {
            var facturaId = await _databaseService.SaveFacturaAsync(factura, medicinasSeleccionadas);
            factura.Id = facturaId;

            // La factura y sus cantidades quedan guardadas en DetalleFacturas.
            // Al regresar a esta página, OnAppearing recargará el stock actualizado.
            await Navigation.PushAsync(new FacturaPage(factura));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar la compra: {ex.Message}", "OK");
            await LoadMedicinasAsync();
        }
        finally
        {
            btnGenerarFactura.IsEnabled = true;
        }
    }

    private static decimal Redondear(decimal valor)
    {
        return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }
}
