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

namespace Ariketa1
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                
                imagen1.Visibility = Visibility.Hidden;
                imagen2.Visibility = Visibility.Hidden;
                imagen3.Visibility = Visibility.Hidden;

                
                if (comboBox.SelectedIndex == 0) // Imagen 1
                    imagen1.Visibility = Visibility.Visible;
                else if (comboBox.SelectedIndex == 1) // Imagen 2
                    imagen2.Visibility = Visibility.Visible;
                else if (comboBox.SelectedIndex == 2) // Imagen 3
                    imagen3.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e) { imagen4.Visibility = Visibility.Visible;}

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e) {imagen4.Visibility = Visibility.Hidden;}

        private void CheckBox2_Checked(object sender, RoutedEventArgs e){imagen5.Visibility = Visibility.Visible;}

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e) { imagen5.Visibility = Visibility.Hidden;}

        private void CheckBox3_Checked(object sender, RoutedEventArgs e){imagen6.Visibility = Visibility.Visible;}

        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e) { imagen6.Visibility = Visibility.Hidden; }

        private void Button_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}