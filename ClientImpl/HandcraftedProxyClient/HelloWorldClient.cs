using System.ServiceModel;
using System.ServiceModel.Channels;

namespace HandcraftedProxyClient
{
    public class HelloWorldClient : ClientBase<IHelloWorldService>, IHelloWorldService
    {
        public HelloWorldClient()
        { }

        public HelloWorldClient(string configurationName)
            : base(configurationName)
        { }

        public HelloWorldClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }

        public string HelloWorld(string name)
        {
            return Channel.HelloWorld(name);
        }
    }
}
