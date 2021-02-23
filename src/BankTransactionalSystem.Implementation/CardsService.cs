using System.Threading.Tasks;

using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;

using Microsoft.Extensions.Logging;

namespace BankTransactionalSystem.Implementation
{
    public class CardsService : ICardsService
    {
        private readonly ILogger<CardsService> logger;
        //private readonly TinyBankDbContext dbContext;

        public CardsService(ILogger<CardsService> _logger/*, TransactionalDbContext _dbContext*/)
        {
            logger = _logger;
            //dbContext = _dbContext;
        }

        public async Task<CreateCardResponse> CreateCardSrvAsync(GenericRequest request)
        {
            CreateCardResponse response = new CreateCardResponse();
            
            return response;
        }
    }
}
