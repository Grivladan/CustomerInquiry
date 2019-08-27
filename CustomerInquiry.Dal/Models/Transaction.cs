using FluentValidation;
using System;

namespace CustomerInquiry.Dal.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Success,
        Failed,
        Canceled
    }

    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.Amount).ScalePrecision(2, 10); 
        }
    }
}
