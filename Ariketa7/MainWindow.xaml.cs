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
    }
}