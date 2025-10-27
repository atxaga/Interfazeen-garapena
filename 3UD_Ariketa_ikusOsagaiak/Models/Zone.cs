using System.Collections.ObjectModel;

namespace _3UD_Ariketa_ikusOsagaiak.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();
    }
}
