using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, 1000000000);
            RuleFor(x => x.Name).Length(0, 30);
            RuleFor(x => x.Email).EmailAddress().Length(0, 25);
            RuleFor(x => x.PhoneNo).InclusiveBetween(1,1000000000);
            RuleFor(x => x.Transactions).Must(x => x.Count <= 5);
        }
    }
}
