using CustomerInquiry.Dal.Models;

namespace CustomerInquiry.Logic.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomersInfo(int? customerId = null, string email = null);
    }
}
