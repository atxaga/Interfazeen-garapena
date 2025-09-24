using Microsoft.VisualBasic;
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

        private void Button_Ejecutar_Click(object sender, RoutedEventArgs e)
        {
            var lehenData = Interaction.InputBox("Ingrese una fecha de la forma dd/mm/aaaa:");
            var hilabeteak = Interaction.InputBox("Ingrese el numero de meses que se agrega a la fecha:"); ;
            var hasieraData = Interaction.InputBox("Ingrese fecha inicial de la forma dd/mm/aaaa:");
            var amaierakoData = Interaction.InputBox("Ingrese fecha final de la forma dd/mm/aaaa:");

            hilabeteakGehitu(sender, e);
            sumaFechas(lehenData, hilabeteak);
            diferenciaFechas(hasieraData, amaierakoData);
        }

        private void hilabeteakGehitu(object sender, RoutedEventArgs e)
        {
            var fechaAhora = DateTime.Now;
            ahoraInput.Text = fechaAhora.ToString("dd/MM/yyyy") +" " + fechaAhora.ToString("HH:mm:ss");
            hoyInput.Text = fechaAhora.ToString("dd/MM/yyyy");
            horaInput.Text = fechaAhora.ToString("HH:mm:ss");

        }

        private void sumaFechas(string lehenData, string hilabeteak)
        {
            sumFechaInput.Text = DateTime.Parse(lehenData).AddMonths(int.Parse(hilabeteak)).ToString("dd/MM/yyyy");
        }

        private void diferenciaFechas(string hasieraData, string amaierakoData)
        {
            var data1 = DateTime.Parse(hasieraData);
            var data2 = DateTime.Parse(amaierakoData);
            var diferentzia = data2 - data1;
            difFechaInput.Text = diferentzia.TotalDays.ToString();
        }

       

        private void Button_limpiar_Click(object sender, RoutedEventArgs e)
        {
            ahoraInput.Text = "";
            hoyInput.Text = "";
            horaInput.Text = "";
            sumFechaInput.Text = "";
            difFechaInput.Text = "";
        }

        private void Button__Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
