using FarmaciaVirtual_Grupo7;

namespace FarmaciaVirtual_Grupo7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnIngresarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}