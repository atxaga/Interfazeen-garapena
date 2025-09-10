using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfAriketa2
{
    public partial class MainWindow : Window
    {
        private readonly string[] frases = new string[5];
        private int fraseIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FraseButton_Click(object sender, RoutedEventArgs e)
        {
            if (fraseIndex < 5)
            {
                frases[fraseIndex] = frasetexbox.Text;
                ((Button)sender).IsEnabled = false;
                frasetexbox.Clear();
                fraseIndex++;

                if (fraseIndex < 5)
                {
                    var nextButton = (Button)FindName($"frase{fraseIndex + 1}");
                    if (nextButton != null)
                        nextButton.IsEnabled = true;
                }
                else
                {
                    unir.IsEnabled = true;
                    frasetexbox.IsEnabled = false;
                }
            }
        }

        private void UnirButton_Click(object sender, RoutedEventArgs e)
        {
            frasetexbox.Text = string.Join(" ", frases);
            unir.IsEnabled = false;
        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            fraseIndex = 0;
            for (int i = 0; i < frases.Length; i++)
                frases[i] = string.Empty;

            frasetexbox.Clear();
            frasetexbox.IsEnabled = true;
            frase1.IsEnabled = true;
            frase2.IsEnabled = false;
            frase3.IsEnabled = false;
            frase4.IsEnabled = false;
            frase5.IsEnabled = false;
            unir.IsEnabled = false;
        }

        private void SalirButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}