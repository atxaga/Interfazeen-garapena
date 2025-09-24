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

namespace Ariketa7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string number = button.Content.ToString();
                if (count == 0)
                {
                    numbrebox.Text = number;
                    count++;
                }
                else
                {
                    numbrebox.Text += number;
                    count++;
                }

            }
                   
        }

        private void Button_quitar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(numbrebox.Text))
            {
                numbrebox.Text = numbrebox.Text.Substring(0, numbrebox.Text.Length - 1);
              
            }
        }

        private void Button_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(numbrebox.Text))
            {
                numbrebox.Text = "0";
                count = 0;
            }
        }

        private void Button_equals_Click(object sender, RoutedEventArgs e)
        {
            string expression = numbrebox.Text;
            char[] operadores = { '+', '-', 'X', '/', '%' };
            int opIndex = expression.IndexOfAny(operadores);

            if (opIndex > 0)
            {
                string left = expression.Substring(0, opIndex);
                string right = expression.Substring(opIndex + 1);
                char op = expression[opIndex];

                if (double.TryParse(left, out double num1) && double.TryParse(right, out double num2))
                {
                    double emaitza = 0;
                    switch (op)
                    {
                        case '+': 
                            emaitza = num1 + num2; 
                            break;

                        case '-': 
                            emaitza = num1 - num2; 
                            break;

                        case 'X': 
                            emaitza = num1 * num2; 
                            break;

                        case '/': 
                            emaitza = num2 != 0 ? num1 / num2 : double.NaN; 
                            break;

                        case '%': 
                            emaitza = num1 % num2; 
                            break;
                    }
                    numbrebox.Text = emaitza.ToString();
                    count = numbrebox.Text.Length;
                }
                else
                {
                    numbrebox.Text = "Error";
                }
            }
        }
    }
}