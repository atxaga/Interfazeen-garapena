using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace Ariketa1
{
    public partial class MainWindow : Window
    {
        string fitxategia = "Data/tareas.xml";
        public ObservableCollection<Ataza> Atazak { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            KargatuXML();
        }

        private void KargatuXML()
        {
                if (!System.IO.File.Exists(fitxategia))
                    return;

                var doc = XElement.Load(fitxategia);

                foreach (var t in doc.Descendants("Tarea"))
                {
                    Atazak.Add(new Ataza
                    {
                        Titulua = t.Element("Titulua")?.Value,
                        Lehentasuna = t.Element("Lehentasuna")?.Value,
                        AzkenEguna = DateTime.Parse(t.Element("AzkenEguna")?.Value),
                        Egina = (t.Element("Egoera")?.Value == "Eginda")
                    });
                }
        }

        private void GordeXML()
        {
                XDocument doc = new XDocument(
                    new XElement("Tareas",
                        from a in Atazak
                        select new XElement("Tarea",
                            new XAttribute("id", Guid.NewGuid()),
                            new XElement("Titulua", a.Titulua),
                            new XElement("Lehentasuna", a.Lehentasuna),
                            new XElement("AzkenEguna", a.AzkenEguna.ToString("yyyy-MM-dd")),
                            new XElement("Egoera", a.Egina ? "Eginda" : "Egin gabe")
                        )
                    )
                );
                doc.Save(fitxategia);
        }

        private void BtnBerria_Click(object sender, RoutedEventArgs e)
        {
            var berria = new Ataza
            {
                Titulua = "Ataza berria",
                Lehentasuna = "Baxua",
                AzkenEguna = DateTime.Today,
                Egina = false
            };
            Atazak.Add(berria);

            GordeXML();
            MessageBox.Show("Atazak gorde dira XML fitxategian.");
        }

        private void BtnEditatu_Click(object sender, RoutedEventArgs e)
        {
            if (dgAtazak.SelectedItem is Ataza aukeratua)
            {
                if (string.IsNullOrWhiteSpace(aukeratua.Titulua))
                {
                    MessageBox.Show("Izenburua ezin da hutsik egon.");
                    return;
                }

                GordeXML();
                MessageBox.Show("Ataza eguneratua XML fitxategian.");
            }
            else
            {
                MessageBox.Show("Aukeratu ataza bat editatzeko.");
            }
        }

        private void BtnEzabatu_Click(object sender, RoutedEventArgs e)
        {
            if (dgAtazak.SelectedItem is Ataza aukeratua)
            {
                Atazak.Remove(aukeratua);
                GordeXML();
                MessageBox.Show("Ataza ezabatu da.");
            }
            else
            {
                MessageBox.Show("Ez da atazarik aukeratu.");
            }
        }

        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Ataza
    {
        public string Titulua { get; set; }
        public string Lehentasuna { get; set; }
        public DateTime AzkenEguna { get; set; } = DateTime.Today;
        public bool Egina { get; set; }
    }
}