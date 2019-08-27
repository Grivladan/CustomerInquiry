using CustomerInquiry.Dal.Models;

namespace CustomerInquiry.Logic.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomerInfo(int? customerId = null, string email = null);
    }
}
