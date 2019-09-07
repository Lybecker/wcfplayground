using System.Diagnostics;
using System.ServiceModel;

public class HelloWorldService : IHelloWorldService
{
    public string HelloWorld(string name)
    {
        var trace = new TraceSource("CustomServer");
        trace.TraceInformation("Received a request from {0}", name);
        
        return string.Format("Hello World, {0}", name);
    }

    public string ComplexOperation(string operationName)
    {
        var trace = new TraceSource("CustomServer");
        trace.TraceInformation("Processing complex operation: {0}", operationName);

        throw new FaultException<TooComplexFault>(
            new TooComplexFault(),
            string.Format("No way I can {0}!", operationName));
    }
}