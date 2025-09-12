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

namespace Ariketa4
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

        private void Button_aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (usuariobox.Text == "iker")
            {
                if (contraseñabox.Password == "iker")
                {
                    resultadolabel.Content = "Ongi etorri sistemara";
                } else
                {
                    resultadolabel.Content = "Identifikatu gabeko erabiltzailea";
                }
            } else
            {
               resultadolabel.Content = "Identifikatu gabeko erabiltzailea";
            }
        }

        private void Button_limpiar_Click(object sender, RoutedEventArgs e)
        {
            resultadolabel.Content = "";
            usuariobox.Clear();
            contraseñabox.Clear();
        }

        private void Button_salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}