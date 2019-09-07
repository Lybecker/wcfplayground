using System;
using System.ServiceModel;

[ServiceContract(Namespace = "www.lybecker.com/blog/HelloWorldService")]
public interface IHelloWorldService
{
    [OperationContract]
    string HelloWorld(string name);

    [FaultContract(typeof(TooComplexFault))]
    [OperationContract]
    string ComplexOperation(string operationName);
}