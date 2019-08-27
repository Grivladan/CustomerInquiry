using CustomerInquiry.Dal.Models;

namespace CustomerInquiry.Dal
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext)
            : base(customerContext)
        {
        }
    }
}
