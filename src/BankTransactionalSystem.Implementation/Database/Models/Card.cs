using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
