using System;
using System.Threading.Tasks;

using BankTransactionalSystem.Implementation.Database;
using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;

using Microsoft.Extensions.Logging;

namespace BankTransactionalSystem.Implementation
{
    public class CardsService : ICardsService
    {
        private readonly ILogger<CardsService> logger;
        private readonly TransactionalSystemDbContext dbContext;

        public CardsService(ILogger<CardsService> _logger, TransactionalSystemDbContext _dbContext)
        {
            logger = _logger;
            dbContext = _dbContext;
        }

        public async Task<CreateCardResponse> CreateCardSrvAsync(GenericRequest request)
        {
            CreateCardResponse response = new CreateCardResponse();
            try
            {
                ValidateRequest(request);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return response;
        }

        private void ValidateRequest(GenericRequest request)
        { 
            if(String.IsNullOrWhiteSpace(request.UserName)) throw new Exception("Please enter your Username.");
        }
    }
}
