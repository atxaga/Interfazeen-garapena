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

namespace Ariketa2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string izena;

        public static string abizena1;

        public static string abizena2;

        public static string dni;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            izena = izena_textbox.Text;
            abizena1 = abizena1_textbox.Text;
            abizena2 = abizena2_textbox.Text;
            dni = dni_textbox.Text;
        }

        private void Button_Visualizar_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"Bienvenido al sistema\n\nNombre: {izena}\nPrimer Apellido: {abizena1}\nSegundo Apellido: {abizena2}\nDNI: {dni}");
        }

        private void Button_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}