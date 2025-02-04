using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{

    public class Callback : ServiceReference1.IService1Callback
    {

        public void AlignReplicasCallback(object state)
        {
            Console.WriteLine("Poravnanje vrednosti!\n=======================================");
        }

        public void NotifyTemperature(int sensorId, double temperature)
        {
            Console.WriteLine($"Senzor {sensorId}: Temperatura = {temperature}°C, Vreme: {DateTime.Now}");
        }
    }

    internal class Program
    {
        static ServiceReference1.IService1 cClient;

        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new Callback());
            cClient = new ServiceReference1.Service1Client(ic);

            Console.WriteLine("Pokretanje senzora");
            cClient.StartSensors();
            cClient.Subscribe();

            Console.WriteLine("Pritisni ENTER za zaustavljanje programa");
            Console.ReadLine();

            Console.WriteLine("Senzori zaustavljeni");
            cClient.StopSensors();  
           
        }
    }
}
