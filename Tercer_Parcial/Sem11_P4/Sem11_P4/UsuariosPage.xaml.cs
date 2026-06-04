using System.Net.Http.Json;

namespace Sem11_P4;

public partial class UsuariosPage : ContentPage
{
	HttpClient client = new HttpClient();
    public UsuariosPage()
	{
		InitializeComponent();
		CargarUsuarios();
    }

	public async void CargarUsuarios()
	{
		try
		{
			var usuarios = await client.GetFromJsonAsync<List<Usuario>>("https://jsonplaceholder.typicode.com/users");

			UsuariosList.ItemsSource = usuarios;
        }
		catch (Exception ex)
		{
			await DisplayAlert("Error", $"No se pudieron cargar los usuarios: {ex.Message}", "OK");
        }
    }
}