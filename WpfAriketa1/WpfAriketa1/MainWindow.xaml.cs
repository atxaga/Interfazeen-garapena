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

namespace WpfAriketa1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(zenb1.Text);
            int b = int.Parse(zenb2.Text);
            int c = int.Parse(zenb3.Text);
            int d = int.Parse(zenb4.Text);

            int resultado = (a + 2 * b + 3 * c + 4 * d) / 4;

            emaitza.Text = resultado.ToString();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            zenb1.Clear();
            zenb2.Clear();
            zenb3.Clear();
            zenb4.Clear();
            emaitza.Clear();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}