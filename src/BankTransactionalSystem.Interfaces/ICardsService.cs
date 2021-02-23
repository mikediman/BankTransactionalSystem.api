using System.Threading.Tasks;

using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;
using BankTransactionalSystem.Types.Result;

namespace BankTransactionalSystem.Interfaces
{
    public interface ICardsService
    {
        public Task<Result<GenericResponse>> CreateCardSrvAsync(GenericRequest request);
        public Task<Result<GenericResponse>> TransactionSrvAsync(TransactionRequest request);
        public Task<Result<GetBalanceResponse>> GetBalanceSrvAsync(GetBalanceRequest request);
    }
}
