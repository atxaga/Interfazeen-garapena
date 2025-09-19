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

namespace Ariketa6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               if (textbox1.Text != "")
                {

                    var textua = textbox1.Text;
                    textbox2.Text = textua;
                    textbox1.Text = "";

                } else if (textbox2.Text != "")
                {
                    
                    var textua = textbox2.Text;
                    textbox3.Text = textua;
                    textbox2.Text = "";

                } else if (textbox3.Text != "")
                {

                    var textua = textbox3.Text;
                    textbox1.Text = textua;
                    textbox3.Text = "";
                }
                   
            }
        }

        private void Button_limpiar_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
        }

        private void Button_salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}