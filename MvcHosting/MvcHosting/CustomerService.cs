using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace MvcHosting
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Customer Get(int id);
    }

    // http://blogs.msdn.com/b/wenlong/archive/2006/01/23/516041.aspx
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService : ICustomerService
    {
        [WebGet(UriTemplate = "/GetCustomer?id={id}")]
        public Customer Get(int id)
        {
            return new Customer() { Id = id, Name = "Anders"};
        }
    }

    [DataContract(Namespace = "http://schemas.lybecker.com/MvcHosting")]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}