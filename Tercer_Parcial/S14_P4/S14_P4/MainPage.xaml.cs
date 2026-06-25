using S14_P4.Models;

namespace S14_P4
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CargarMedicamentos();
        }

        public async void CargarMedicamentos()
        {
            medicamentosView.ItemsSource =
                await App.Database.GetMedicamentosAsync();
        }

        public async void OnAgregarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }

        public async void OnEditarClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var med = button?.CommandParameter as Medicamento;


            if (med != null)
            {
                await Navigation.PushAsync(new RegistroPage(med));
            }
        }

        public async void OnEliminarClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var med = button?.CommandParameter as Medicamento;


            if (med != null)
            {
                await App.Database.DeleteMedicamentoAsync(med);
                CargarMedicamentos();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarMedicamentos();
        }


    }
}
