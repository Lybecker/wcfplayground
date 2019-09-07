using System;
using System.Diagnostics;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();

            var ts = new TraceSource("CustomClient");
            ts.TraceInformation("Client Started...");

            var factory = new ChannelFactory<IHelloWorldService>("HelloWorldEndpoint");

            var proxy = factory.CreateChannel();

            ts.TraceInformation("Calling HelloWorld...");
            var message = proxy.HelloWorld("Anders");
            ts.TraceInformation("Received message: {0}", message);
            Console.ReadLine();

            try
            {
                proxy.ComplexOperation("Add");
            }
            catch (FaultException<TooComplexFault> ex)
            {
                //ts.TraceEvent(TraceEventType.Warning, 42, "TooComplexFault received: {0}", ex.Message);
            }
            Console.ReadLine();
        }
    }
}
