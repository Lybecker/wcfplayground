using System;
using System.Diagnostics;
using System.ServiceModel;

class Program
{
    static void Main(string[] args)
    {
        using (var host = new ServiceHost(typeof(HelloWorldService)))
        {
            host.Open();

            Console.WriteLine("The Service is running.");
            Console.WriteLine("Press [ENTER] to terminate...");
            Console.ReadLine();
        }
    }
}