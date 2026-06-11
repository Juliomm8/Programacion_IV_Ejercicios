namespace Sem12_P4
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SuperHeroViewModel();
        }

    }
}
