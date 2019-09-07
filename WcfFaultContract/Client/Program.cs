using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using Lybecker.Shared;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IService>(new NetTcpBinding(),
                                                       new EndpointAddress("net.tcp://localhost:4242/Service"));

            Console.WriteLine("Press [ENTER] when Service is ready...");
            Console.ReadLine();

            var proxy = factory.CreateChannel();
            var channel = (IChannel)proxy;

            try
            {
                Console.WriteLine("Calling ThrowException");
                proxy.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                /** Do Nothing **/
            }
            Console.WriteLine("Proxy state: {0}", channel.State);

            try
            {
                Console.WriteLine("Calling ThrowException again (will fail due to the channel is in faulted state)");
                proxy.ThrowException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Close the faulted proxy
            channel.Abort();

            Console.WriteLine();
            Console.WriteLine("Service throwing faults and not Exceptions");


            proxy = factory.CreateChannel();
            channel = (IChannel)proxy;

            try
            {
                Console.WriteLine("Calling ThrowFault");
                proxy.ThrowFault();
                Console.WriteLine("Proxy state: {0}", channel.State);
                Console.WriteLine("Calling ThrowFault again");
                proxy.ThrowFault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                /** Do Nothing **/
            }

            Console.WriteLine("Proxy state: {0}", channel.State);

            try
            {
                Console.WriteLine("Calling ThrowFault again");
                proxy.ThrowFault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                /** Do Nothing **/
            }
            channel.Close();

            Console.WriteLine("Press [ENTER] to terminate...");
            Console.ReadLine();
        }
    }
}
