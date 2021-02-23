using BankTransactionalSystem.Types.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactionalSystem.Implementation.Database.Models
{
    public class Limit
    {
        public Guid LimitId { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
