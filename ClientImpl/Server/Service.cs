using System.Diagnostics;
using System.ServiceModel;

public class HelloWorldService : IHelloWorldService
{
    public string HelloWorld(string name)
    {
        var trace = new TraceSource("Lybecker");
        trace.TraceInformation("Received a request from {0}", name);
        
        return string.Format("Hello World, {0}", name);
    }
}