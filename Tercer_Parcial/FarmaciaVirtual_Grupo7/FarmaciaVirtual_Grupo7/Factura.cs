using SQLite;

namespace FarmaciaVirtual_Grupo7;

[Table("Facturas")]
public class Factura
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string NumeroFactura { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Descuento { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
}
