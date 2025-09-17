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
        // Store style settings
        private FontFamily _fontFamily = new FontFamily("Segoe UI");
        private FontWeight _fontWeight = FontWeights.Normal;
        private FontStyle _fontStyle = FontStyles.Normal;
        private double _fontSize = 12;
        private TextDecorationCollection _textDecorations = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_comic_Click(object sender, RoutedEventArgs e)
        {
            _fontFamily = new FontFamily("Comic Sans MS");
        }

        private void Button_negrita_Click(object sender, RoutedEventArgs e)
        {
            _fontWeight = FontWeights.Bold;
        }

        private void Button_tachado_Click(object sender, RoutedEventArgs e)
        {
            _textDecorations = TextDecorations.Strikethrough;
        }

        private void Button_sumtamaño_Click(object sender, RoutedEventArgs e)
        {
            _fontSize += 2;
        }

        private void Button_courier_Click(object sender, RoutedEventArgs e)
        {
            _fontFamily = new FontFamily("Courier New");
        }

        private void Button_cursiva_Click(object sender, RoutedEventArgs e)
        {
            _fontStyle = FontStyles.Italic;
        }

        private void Button_subrayado_Click(object sender, RoutedEventArgs e)
        {
            _textDecorations = TextDecorations.Underline;
        }

        private void Button_restamaño_Click(object sender, RoutedEventArgs e)
        {
            _fontSize = Math.Max(2, _fontSize - 2);
        }

        private void Button_salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Apply styles when "Seleccionar" is clicked
        private void Button_Seleccionar_Click(object sender, RoutedEventArgs e)
        {
            textoPrueba.Text = ((TextBox)this.FindName("textBox")).Text;
            textoPrueba.FontFamily = _fontFamily;
            textoPrueba.FontWeight = _fontWeight;
            textoPrueba.FontStyle = _fontStyle;
            textoPrueba.FontSize = _fontSize;
            textoPrueba.TextDecorations = _textDecorations;
        }
    }
}