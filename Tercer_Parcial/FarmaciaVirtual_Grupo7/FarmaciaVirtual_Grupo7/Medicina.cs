using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TableAttribute = SQLite.TableAttribute;

namespace FarmaciaVirtual_Grupo7;

[Table("Medicinas")]
public class Medicina : INotifyPropertyChanged
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Stock { get; set; }

    private int _cantidad;

    [Ignore]
    public int Cantidad
    {
        get => _cantidad;
        set
        {
            if (_cantidad == value)
                return;

            _cantidad = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(StockRestante));
        }
    }

    [Ignore]
    public decimal Subtotal => Precio * Cantidad;

    [Ignore]
    public int StockRestante => Math.Max(Stock - Cantidad, 0);

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
