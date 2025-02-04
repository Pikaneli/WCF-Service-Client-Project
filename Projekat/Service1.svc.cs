using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Projekat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Service1 : IService1
    {
        private readonly Dictionary<int, Timer> _sensorTimers = new Dictionary<int, Timer>();
        private readonly Random _random = new Random();
        private readonly object _lock = new object();
        private readonly TemperatureDbContext _dbContext = new TemperatureDbContext();
        private readonly Dictionary<int, List<double>> recnik = new Dictionary<int, List<double>>();
        private readonly List<ITemperatureSensorCallback> _clients = new List<ITemperatureSensorCallback>();
        private Timer _alignReplicasTimer;
    
        // Metoda koja omogucava da klijent bude obavesten na svaku generisanu vrednost od strane senzora
        public void Subscribe()
        {
            ITemperatureSensorCallback callback = OperationContext.Current.GetCallbackChannel<ITemperatureSensorCallback>();
            if(!_clients.Contains(callback))
            {
                _clients.Add(callback);
            }    
        }

        // Brisanja sadrzaja u svim bazama
        private void ClearAllSensorData()
        {
            lock (_lock)
            {
                _dbContext.TemperatureReadings.RemoveRange(_dbContext.TemperatureReadings);
                _dbContext.TemperatureReadings2.RemoveRange(_dbContext.TemperatureReadings2);
                _dbContext.TemperatureReadings3.RemoveRange(_dbContext.TemperatureReadings3);
                _dbContext.TemperatureReadings4.RemoveRange(_dbContext.TemperatureReadings4);
                _dbContext.TemperatureReadings5.RemoveRange(_dbContext.TemperatureReadings5);
                _dbContext.TemperatureReadings6.RemoveRange(_dbContext.TemperatureReadings6);
                _dbContext.TemperatureReadings7.RemoveRange(_dbContext.TemperatureReadings7);
                _dbContext.TemperatureReadings8.RemoveRange(_dbContext.TemperatureReadings8);
                _dbContext.TemperatureReadings9.RemoveRange(_dbContext.TemperatureReadings9);
                _dbContext.TemperatureReadings10.RemoveRange(_dbContext.TemperatureReadings10);

                _dbContext.SaveChanges();
            }       
        }

        // Pokretanje senzora i tajmera za metodu poravnanja vrednosti u bazi
        public void StartSensors()
        {
            ClearAllSensorData();
            // Funkcija se poziva nakon prvog minuta izvrsavanja i svaki minut nakon toga
            _alignReplicasTimer = new Timer(AlignReplicasCallback, null, 60000, 60000);

            // Simuliranje vrednosti svih senzora
            for (int i = 1; i <= 10; i++)
            {
                int sensorId = i;
                Timer timer = new Timer(SimulateSensorReading, sensorId, 0, _random.Next(1000, 10000));
                _sensorTimers[sensorId] = timer;
            }
        }

        // Zaustavljanje senzora i tajmera za funkciju poravnanja vrednosti
        public void StopSensors()
        {
            _alignReplicasTimer?.Dispose();
            foreach (var timer in _sensorTimers.Values)
            {
                timer.Dispose();
            }
            _sensorTimers.Clear();
            Environment.Exit(0);
        }

        // Pokretanje funckije Align Replicas i prikaz izvrsavanja na strani klijenta
        private void AlignReplicasCallback(object state)
        {
            AlignReplicas();

            foreach (var client in _clients)
            {
                try
                {
                    client.AlignReplicasCallback("Poravnanje vrednosti!\n=======================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to notify client about AlignReplicas execution: {ex.Message}");
                }
            }
        }

        public void AlignReplicas()
        {
            lock (_lock)
            {
                foreach (var sensorId in recnik.Keys)
                {
                    var readings = recnik[sensorId];
                    if (!readings.Any()) continue;

                    // Srednja vrednost pojedinacnog senzora
                    double averageValue = readings.Average();

                    // Prihvatljiva granica
                    double acceptableRange = 5;
                    double lowerBound = averageValue - acceptableRange;
                    double upperBound = averageValue + acceptableRange;

                    // Pronalazenje vrednosti
                    double? chosenValue = readings
                        .Where(value => value >= lowerBound && value <= upperBound)
                        .LastOrDefault(); 

                    // U suprotnom uzmi poslednju vrednost
                    if (chosenValue == null || chosenValue == 0)
                    {
                        chosenValue = readings.Last(); 
                    }

                    AddReadingToDatabase(sensorId, chosenValue.Value);

                    // Brisanje sadrzaja u recniku
                    recnik[sensorId].Clear();
                }

                _dbContext.SaveChanges();
            }
        }

        // Uzimanje poslednje vrednosti iz baze
        private dynamic GetLatestReading(int sensorId)
        {
            if (sensorId == 1)
                return _dbContext.TemperatureReadings.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 2)
                return _dbContext.TemperatureReadings2.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 3)
                return _dbContext.TemperatureReadings3.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 4)
                return _dbContext.TemperatureReadings4.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 5)
                return _dbContext.TemperatureReadings5.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 6)
                return _dbContext.TemperatureReadings6.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 7)
                return _dbContext.TemperatureReadings7.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 8)
                return _dbContext.TemperatureReadings8.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 9)
                return _dbContext.TemperatureReadings9.OrderByDescending(r => r.Timestamp).FirstOrDefault();
            if (sensorId == 10)
                return _dbContext.TemperatureReadings10.OrderByDescending(r => r.Timestamp).FirstOrDefault();

            return null;
        }

        // Cuvanje vrednosti u bazi
        private void AddReadingToDatabase(int sensorId, double value)
        {
            switch (sensorId)
            {
                case 1:
                    _dbContext.TemperatureReadings.Add(new TemperatureReading { Timestamp = DateTime.Now, Value = value });
                    break;
                case 2:
                    _dbContext.TemperatureReadings2.Add(new TemperatureReading2 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 3:
                    _dbContext.TemperatureReadings3.Add(new TemperatureReading3 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 4:
                    _dbContext.TemperatureReadings4.Add(new TemperatureReading4 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 5:
                    _dbContext.TemperatureReadings5.Add(new TemperatureReading5 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 6:
                    _dbContext.TemperatureReadings6.Add(new TemperatureReading6 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 7:
                    _dbContext.TemperatureReadings7.Add(new TemperatureReading7 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 8:
                    _dbContext.TemperatureReadings8.Add(new TemperatureReading8 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 9:
                    _dbContext.TemperatureReadings9.Add(new TemperatureReading9 { Timestamp = DateTime.Now, Value = value });
                    break;
                case 10:
                    _dbContext.TemperatureReadings10.Add(new TemperatureReading10 { Timestamp = DateTime.Now, Value = value });
                    break;
            }
        }

        // Simuliranje vrednosti sa senzora
        private void SimulateSensorReading(object state)
        {
            int sensorId = (int)state;
            double temperature = Math.Round(_random.NextDouble() * 50, 2);

            lock (_lock)
            {
                if (!recnik.ContainsKey(sensorId))
                {
                    recnik[sensorId] = new List<double>();
                }

                recnik[sensorId].Add(temperature);

            }

            foreach (var client in _clients)
            {
                try
                {
                    client.NotifyTemperature(sensorId, temperature);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Failed to notify client: {ex.Message}");
                }
            }

        }

    }
}
