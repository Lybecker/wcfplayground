using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Lybecker.Shared;

namespace Lybecker.Server
{
    public class FaultContractServiceBehavior : IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var endpoint in serviceDescription.Endpoints)
            {
                if (endpoint.Contract.Name != "IMetadataExchange")
                {
                    foreach (var operationDescription in endpoint.Contract.Operations)
                    {
                        var fcExists = from fc in operationDescription.Faults
                                       where fc.DetailType == typeof(ServiceFault)
                                       select fc;

                        if (fcExists.Count() != 1)
                        {
                            var msg = string.Format("FaultContractServiceBehavior requires a FaultContract(typeof(ServiceFault)) on each operation contract ({0}).",
                                operationDescription.Name);

                            throw new InvalidOperationException(msg);
                        }
                    }
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler handler = new GeneralErrorHandler();

            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(handler);
            }
        }
    }
}