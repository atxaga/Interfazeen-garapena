using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using _3UD_Ariketa_ikusOsagaiak.Models;

namespace _3UD_Ariketa_ikusOsagaiak.Views.Components
{
    public partial class SeatMapControl : UserControl
    {
        public SeatMapControl()
        {
            InitializeComponent();
        }

        // --- Propiedad: Seats ---
        public ObservableCollection<Seat> Seats
        {
            get => (ObservableCollection<Seat>)GetValue(SeatsProperty);
            set => SetValue(SeatsProperty, value);
        }

        public static readonly DependencyProperty SeatsProperty =
            DependencyProperty.Register(nameof(Seats),
                typeof(ObservableCollection<Seat>),
                typeof(SeatMapControl),
                new PropertyMetadata(null));

        // --- Propiedad: Columns ---
        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register(nameof(Columns),
                typeof(int),
                typeof(SeatMapControl),
                new PropertyMetadata(6));

        // --- Propiedad: SeatClickCommand ---
        public ICommand SeatClickCommand
        {
            get => (ICommand)GetValue(SeatClickCommandProperty);
            set => SetValue(SeatClickCommandProperty, value);
        }

        public static readonly DependencyProperty SeatClickCommandProperty =
            DependencyProperty.Register(nameof(SeatClickCommand),
                typeof(ICommand),
                typeof(SeatMapControl),
                new PropertyMetadata(null));
    }
}
