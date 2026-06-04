namespace Sem11_P4
{
    public partial class MainPage : ContentPage
    {

        public MainPage() 
        {
            InitializeComponent();
        }

        public async void OnNavegateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuariosPage());
        }
    }
}
