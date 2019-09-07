using System;
using System.ServiceModel;

namespace Lybecker.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Service), new Uri("net.tcp://localhost:4242/Service")))
            {
                //TODO: Uncomment this
                //host.Description.Behaviors.Add(new FaultContractServiceBehavior());
                // Remember to add [FaultContract(typeof(ServiceFault))] to all Operations in the Service Contract
                host.Open();

                Console.WriteLine("WCF server {0} Started....", typeof(Service).Name);
                Console.WriteLine("Press [ENTER] to terminate.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
