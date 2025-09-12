using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ariketa3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] inputNumeros = new string[4];
        private int numeroIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;

            if (boton.Content?.ToString() == "Limpiar")
            {
                numeroIndex = 0;
                for (int i = 0; i < inputNumeros.Length; i++)
                    inputNumeros[i] = string.Empty;

                numerotextbox.Clear();
                numerotextbox.IsEnabled = true;
                numerolabel.Content = "Numero 1";
                boton.Content = "Siguiente";
                return;
            }

            if (numeroIndex < 4)
            {
                inputNumeros[numeroIndex] = numerotextbox.Text;
                numerotextbox.Clear();
                numeroIndex++;
                if (numeroIndex < 4)
                {
                    numerolabel.Content = "Numero " + (numeroIndex + 1);
                }
                else
                {
                    boton.Content = "Resultado";
                    numerotextbox.IsEnabled = false;
                }
            }
            else 
            {
                    var resultado = (
                        int.Parse(inputNumeros[0]) +
                        (int.Parse(inputNumeros[0]) * int.Parse(inputNumeros[1])) +
                        (int.Parse(inputNumeros[1]) * int.Parse(inputNumeros[2])) +
                        (int.Parse(inputNumeros[2]) * int.Parse(inputNumeros[3]))
                    ) / 4;
                    numerolabel.Content = "Resultado: ";
                    numerotextbox.Text = resultado.ToString();
                    boton.Content = "Limpiar";
                
            }
        }

        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}