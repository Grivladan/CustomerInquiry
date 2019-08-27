using System;

namespace CustomerInquiry.Dal.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Status Staus { get; set; }
    }

    public enum Status
    {
        Success,
        Failed,
        Canceled
    }
}
