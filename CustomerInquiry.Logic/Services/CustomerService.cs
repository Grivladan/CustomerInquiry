using System.Linq;
using CustomerInquiry.Dal;
using CustomerInquiry.Dal.Models;
using CustomerInquiry.Logic.Helpers;
using CustomerInquiry.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Logic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerInfo(int? customerId = null, string email = null)
        {
            return _customerRepository.GetAll().WhereIf(customerId != null, x => x.Id == customerId)
                .WhereIf(email != null, x => x.Email == email).Include(x => x.Transactions).SingleOrDefault();
        }
    }
}
