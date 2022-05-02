using MathServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceSelfHostMathLibrary = null;

            try
            {
                serviceSelfHostMathLibrary = new ServiceHost(typeof(MathService));
                serviceSelfHostMathLibrary.Open();

                Console.WriteLine("Hosting został uruchomiony");
                Console.WriteLine("Serwis nasłuchuje żądań klientów na adresie:");
                Console.WriteLine();

                foreach (var serviceSelfHostEndpoint in serviceSelfHostMathLibrary.Description.Endpoints)
                {
                    Console.WriteLine($"Adres: {serviceSelfHostEndpoint.Address} Wiązanie: {serviceSelfHostEndpoint.Binding.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Wciśnięcie dowolnego klawisza kończy pracę");
                Console.ReadKey();

                serviceSelfHostMathLibrary.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                if (serviceSelfHostMathLibrary != null && serviceSelfHostMathLibrary.State == CommunicationState.Opened)
                    serviceSelfHostMathLibrary.Close();
            }
        }
    }
}
