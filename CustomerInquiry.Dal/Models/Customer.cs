using System.Collections.Generic;

namespace CustomerInquiry.Dal.Models
{
    public class Customer
    {
        public Customer()
        {
            Transactions = new List<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
