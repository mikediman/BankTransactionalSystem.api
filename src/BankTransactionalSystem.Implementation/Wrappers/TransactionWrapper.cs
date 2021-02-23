using BankTransactionalSystem.Implementation.Database.Models;
using BankTransactionalSystem.Types.Requests;

namespace BankTransactionalSystem.Implementation.Wrappers
{
    public class TransactionWrapper
    {
        public Card card { get; set; }
        public Limit limit { get; set; }
        public TransactionRequest request { get; set; }
    }
}
