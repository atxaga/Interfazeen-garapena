using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ariketa3
{
    public partial class MainWindow : Window
    {
        public static int gosaria = 3;
        public static int bazkaria = 9;
        public static double afaria = 15.5;
        public static double km = 0.25;
        public static int bidaiordu = 18;
        public static double lanordu = 42;

        double totalDietas = 0;
        double totalViajes = 0;
        double totalTrabajo = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        // ENTER como TAB salvo en los TextBox de cálculo
        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.FocusedElement == DietasTotalText ||
                    Keyboard.FocusedElement == ViajesTotalText ||
                    Keyboard.FocusedElement == TrabajoTotalText ||
                    Keyboard.FocusedElement == TotalFinalText)
                {
                    return; // lo maneja su propio KeyDown
                }

                e.Handled = true;
                MoveToNextUIElement();
            }
        }

        private void MoveToNextUIElement()
        {
            TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            if (elementWithFocus != null)
                elementWithFocus.MoveFocus(request);
        }

        // ===== BLOQUES DE CÁLCULO =====
        private void DietasTotalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                totalDietas = 0;
                if (DesayunoCheck.IsChecked == true) totalDietas += gosaria;
                if (ComidaCheck.IsChecked == true) totalDietas += bazkaria;
                if (CenaCheck.IsChecked == true) totalDietas += afaria;

                DietasTotalText.Text = totalDietas.ToString("0.00");
                MoveToNextUIElement();
            }
        }

        private void ViajesTotalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                totalViajes = 0;
                if (double.TryParse(KmText.Text, out double kmVal)) totalViajes += kmVal * km;
                if (double.TryParse(HorasViajeText.Text, out double hViaje)) totalViajes += hViaje * bidaiordu;

                ViajesTotalText.Text = totalViajes.ToString("0.00");
                MoveToNextUIElement();
            }
        }

        private void TrabajoTotalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                totalTrabajo = 0;
                if (double.TryParse(HorasTrabajoText.Text, out double hTrabajo)) totalTrabajo += hTrabajo * lanordu;

                TrabajoTotalText.Text = totalTrabajo.ToString("0.00");
                MoveToNextUIElement();
            }
        }

        private void TotalFinalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double totalFinal = totalDietas + totalViajes + totalTrabajo;
                TotalFinalText.Text = totalFinal.ToString("0.00") + " €";

                // Opcional: mover el foco al botón Salir
                MoveToNextUIElement();
            }
        }
    }
}
