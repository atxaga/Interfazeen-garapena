using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using _3UD_Ariketa_ikusOsagaiak.Models;

namespace _3UD_Ariketa_ikusOsagaiak.Services
{
    public class ReservationService
    {
        private const string FilePath = "Data/reservations.json";

        // Diccionario interno con todas las zonas
        private Dictionary<string, Zone> _zones = new Dictionary<string, Zone>();

        public ReservationService()
        {
            LoadAllZones();
        }

        // Devuelve la zona y crea si no existe
        public Zone LoadZone(string mode)
        {
            if (!_zones.ContainsKey(mode))
            {
                int totalSeats = mode switch
                {
                    "Bus" => 15,
                    "Train" => 20,
                    "Airplane" => 25,
                    _ => 10
                };

                var zone = new Zone
                {
                    Name = mode,
                    Seats = new ObservableCollection<Seat>()
                };

                for (int i = 1; i <= totalSeats; i++)
                    zone.Seats.Add(new Seat { Id = $"{mode[0]}{i:D2}" });

                _zones[mode] = zone;

                // Guardamos al crear para asegurar que exista en JSON
                SaveAllZones();
            }

            return _zones[mode];
        }

        // Guarda todas las zonas en JSON
        public void SaveAllZones()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

            // Convertimos ObservableCollection a List para que JSON lo acepte
            var jsonCompatibleDict = new Dictionary<string, object>();
            foreach (var kvp in _zones)
            {
                jsonCompatibleDict[kvp.Key] = new
                {
                    kvp.Value.Name,
                    Seats = new List<Seat>(kvp.Value.Seats)
                };
            }

            var json = JsonSerializer.Serialize(jsonCompatibleDict, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }

        public void LoadAllZones()
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, "{}"); 
                return;
            }

            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(FilePath, "{}");
                return;
            }

            try
            {
                var dict = JsonSerializer.Deserialize<Dictionary<string, Zone>>(json);
                if (dict != null)
                {
                    _zones = dict;

                    foreach (var zone in _zones.Values)
                        zone.Seats = new ObservableCollection<Seat>(zone.Seats);
                }
            }
            catch (JsonException)
            {
                _zones.Clear();
                File.WriteAllText(FilePath, "{}");
            }
        }
    }
}

