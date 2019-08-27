using CustomerInquiry.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Dal
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
