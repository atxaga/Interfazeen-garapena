using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace Ariketa1
{
    public partial class MainWindow : Window
    {
        string fitxategia = "Data/tareas.xml";
        ObservableCollection<Ataza> atazak = new ObservableCollection<Ataza>();

        public MainWindow()
        {
            InitializeComponent();
            KargatuXML();
            dgAtazak.ItemsSource = atazak;
        }

        private void KargatuXML()
        {
            try
            {
                if (!System.IO.File.Exists(fitxategia))
                    return;

                XDocument doc = XDocument.Load(fitxategia);

                atazak.Clear();
                foreach (var t in doc.Descendants("Tarea"))
                {
                    atazak.Add(new Ataza
                    {
                        Id = (int)t.Attribute("id"),
                        Titulua = t.Element("Titulua")?.Value,
                        Lehentasuna = t.Element("Lehentasuna")?.Value,
                        AzkenEguna = DateTime.Parse(t.Element("AzkenEguna")?.Value),
                        Egina = (t.Element("Egoera")?.Value == "Eginda")
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea XML irakurtzean: " + ex.Message);
            }
        }

        private void GordeXML()
        {
            try
            {
                XDocument doc = new XDocument(
                    new XElement("Tareas",
                        from a in atazak
                        select new XElement("Tarea",
                            new XAttribute("id", a.Id),
                            new XElement("Titulua", a.Titulua),
                            new XElement("Lehentasuna", a.Lehentasuna),
                            new XElement("AzkenEguna", a.AzkenEguna.ToString("yyyy-MM-dd")),
                            new XElement("Egoera", a.Egina ? "Eginda" : "Egin gabe")
                        )
                    )
                );
                doc.Save(fitxategia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorea XML gordetzean: " + ex.Message);
            }
        }

        private void BtnBerria_Click(object sender, RoutedEventArgs e)
        {
            // Validar tareas antes de guardar
            foreach (var a in atazak)
            {
                if (string.IsNullOrWhiteSpace(a.Titulua))
                {
                    MessageBox.Show("Ataza guztiek titulua izan behar dute.");
                    return;
                }

                if (a.AzkenEguna < DateTime.Today)
                {
                    MessageBox.Show($"'{a.Titulua}' atazaren muga-eguna gaurkoa edo handiagoa izan behar da.");
                    return;
                }

                if (a.Id == 0)
                    a.Id = new Random().Next(1000, 9999);
            }

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

                if (aukeratua.AzkenEguna < DateTime.Today)
                {
                    MessageBox.Show("Muga-eguna gaurkoa edo handiagoa izan behar da.");
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
                atazak.Remove(aukeratua);
                GordeXML();
            }
            else
            {
                MessageBox.Show("Ez da atazarik aukeratu.");
            }
        }

        private void BtnIrten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    public class Ataza
    {
        public int Id { get; set; }
        public string Titulua { get; set; }
        public string Lehentasuna { get; set; }
        public DateTime AzkenEguna { get; set; } = DateTime.Today;
        public bool Egina { get; set; }
    }
}
