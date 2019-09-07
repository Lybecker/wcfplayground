using System.Runtime.Serialization;

namespace Lybecker.Shared
{
    /// <summary>
    /// Fault when application fails. An error in the application exists.
    /// </summary>
    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string Message { get; set; }

        public ServiceFault(string message)
        {
            Message = message;
        }
    }
}