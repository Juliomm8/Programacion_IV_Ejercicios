namespace S8_P4_CalculadoraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnOperacion(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNum1.Text, out double num1) ||
                !double.TryParse(txtNum2.Text, out double num2))
            {
                lblResultado.Text = "Datos inválidos, no sea gil";
                return;
            }

            string operacion = ((Button)sender).Text;
            double resultado = 0;
            switch (operacion) {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        lblResultado.Text = "No se puede dividir por cero, no sea gil";
                        return;
                    }
                    resultado = num1 / num2;
                    break;
            };

            lblResultado.Text = $"El resultado es: {resultado}";
        }

        

    }
}
