namespace S9_P4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public int ObtenerNumero()
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                return numero;
            }
            else
            {
                DisplayAlert("Error", "Por favor ingresa un número válido.", "OK");
                return 0;
            }
        }

        public void OnFibonacci(object sender, EventArgs e)
        {
            int n = ObtenerNumero();
            if (n <= 0) return;
            List<int> serie
                = new List<int> { 0, 1 };

            for (int i = 2; i < n; i++)
            {
                serie.Add(serie[i - 1] + serie[i - 2]);
            }
            lstResultados.ItemsSource = serie.Take(n).ToList();
        }

        public bool OnPrimo(int numero)
        {
            if (numero < 2) return false;
            for (int i = 2; i <= Math.Sqrt(numero); i++)
                if (numero % i == 0) return false;
            return true;
        }

        public void OnPrimo(object sender, EventArgs e)
        {
            int n = ObtenerNumero();
            if (n <= 0) return;
            List<int> serie = new List<int>();
            for (int i = 2; serie.Count < n; i++)
                if (OnPrimo(i)) serie.Add(i);
            lstResultados.ItemsSource = serie;
        }

        public void OnPares(object sender, EventArgs e)
        {
            int n = ObtenerNumero();
            if (n <= 0) return;
            List<int> serie = new List<int>();
            for (int i = 0; serie.Count < n; i += 2)
                serie.Add(i);
            lstResultados.ItemsSource = serie;
        }

        public void OnImpares(object sender, EventArgs e)
        {
            int n = ObtenerNumero();
            if (n <= 0) return;
            List<int> serie = new List<int>();
            for (int i = 1; serie.Count < n; i += 2)
                serie.Add(i);
            lstResultados.ItemsSource = serie;
        }
    }
}
