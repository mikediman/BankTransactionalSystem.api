using System;

namespace BankTransactionalSystem.Implementation.Database.Models
{
    public class Card
    {
        public Guid CardId { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string CardOwner { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
