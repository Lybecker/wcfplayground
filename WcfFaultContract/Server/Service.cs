using System;
using System.ServiceModel;
using Lybecker.Shared;

namespace Lybecker.Server
{
    public class Service : IService
    {
        public string ThrowException()
        {
            throw new Exception();
        }

        public string ThrowFault()
        {
            throw new FaultException<Exception>(new Exception());
        }
    }
}