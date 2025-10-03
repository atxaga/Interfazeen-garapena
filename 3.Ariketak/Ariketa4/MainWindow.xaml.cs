using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ariketa4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
            {
                txtEditor.SelectedText = "";
            }
            else
            {
                
                int pos = txtEditor.CaretIndex;
                if (pos < txtEditor.Text.Length && pos >= 0)
                {
                    txtEditor.Text = txtEditor.Text.Remove(pos, 1);
                    txtEditor.CaretIndex = pos; 
                }
            }
        }

        
        private void Arial_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Arial");
        }

        private void Courier_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Courier New");
        }

        private void Impact_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Impact");
        }

        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Symbol");
        }
    }
}
