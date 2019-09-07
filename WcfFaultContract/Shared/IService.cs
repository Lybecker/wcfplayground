using System;
using System.ServiceModel;

namespace Lybecker.Shared
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string ThrowException();

        [FaultContract(typeof(Exception))]
        [OperationContract]
        string ThrowFault();
    }
}
