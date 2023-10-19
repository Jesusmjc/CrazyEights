using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CrazyEightsServicio.ManejadorJugadores)))
            {
                host.Open();
                Console.WriteLine("El Servidor está activo");
                Console.ReadLine();
            }         
        }
    }
}
