namespace DragonBallCatalog;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Lista con personajes y objetos del universo Dragon Ball
        var productos = new List<Producto>
        {
            new Producto { Name = "Goku", Description = "Guerrero Saiyajin, experto en el Kamehameha" },
            new Producto { Name = "Radar del Dragón", Description = "Dispositivo para encontrar las Esferas del Dragón" },
            new Producto { Name = "Capsula Hoi-Poi", Description = "Guarda autos, casas y más en una cápsula" },
            new Producto { Name = "Esfera de 4 estrellas", Description = "La esfera más especial de Goku, heredada de su abuelo" }
        };

        // Asignar lista al ListView
        miListView.ItemsSource = productos;

        // Evento para mostrar mensaje al tocar
        miListView.ItemTapped += (sender, e) =>
        {
            if (e.Item is Producto prod)
            {
                DisplayAlert("¡Objeto Z Seleccionado!", $"¡Has seleccionado a: {prod.Name}!", "¡Entendido!");
            }
        };
    }
}