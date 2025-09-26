using System.Windows;
using System.Windows.Controls;

namespace Ariketa2
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

        private void Button_Añadir_Click(object sender, RoutedEventArgs e)
        {
            string nuevoAmigo = txtAmigoNuevo.Text.Trim();
            if (!string.IsNullOrEmpty(nuevoAmigo) && !lstAmigos.Items.Contains(nuevoAmigo))
            {
                lstAmigos.Items.Add(nuevoAmigo);
                txtAmigoNuevo.Clear();
            }
            else
            {
                MessageBox.Show("Introduzca datos para poder añadirlos");
            }
        }

        private void Button_Amigos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstAmigos.SelectedItem != null)
            {
                txtAmigoSeleccionado.Text = lstAmigos.SelectedItem.ToString();
            }
        }

        private void Button_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lstAmigos.SelectedItem != null)
            {
                lstAmigos.Items.Remove(lstAmigos.SelectedItem);
                txtAmigoSeleccionado.Clear();
            } else
            {
                MessageBox.Show("Introduzca datos para poder añadirlos");
            }
        }

        private void Button_BorrarLista_Click(object sender, RoutedEventArgs e)
        {
            lstAmigos.Items.Clear();
            txtAmigoSeleccionado.Clear();
        }

        private void Button_Salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}