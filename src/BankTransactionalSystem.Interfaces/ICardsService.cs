using System.Threading.Tasks;

using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;

namespace BankTransactionalSystem.Interfaces
{
    public interface ICardsService
    {
        public Task<CreateCardResponse> CreateCardSrvAsync(GenericRequest request);
    }
}
