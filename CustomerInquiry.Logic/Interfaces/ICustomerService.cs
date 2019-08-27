using CustomerInquiry.Dal.Models;
using System.Collections.Generic;

namespace CustomerInquiry.Logic.Interfaces
{
    public interface ICustomerService
    {
        ICollection<Customer> GetCustomersInfo(int? customerId = null, string email = null);
    }
}
