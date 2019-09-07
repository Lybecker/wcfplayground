using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Lybecker.Server
{
    public class GeneralErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception exception, MessageVersion version, ref Message fault)
        {
            if (exception is FaultException)
                return; // Already a fault, so we do not need to create a fault

            var faultException = new FaultException("Server error. Look in the logs.");

            var messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, faultException.Action);
        }

        public bool HandleError(Exception exception)
        {
            //TODO: Log the exception here.

            return false;
        }
    }
}