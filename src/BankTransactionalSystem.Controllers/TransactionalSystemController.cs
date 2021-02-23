using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;
using BankTransactionalSystem.Types.Result;

namespace BankTransactionalSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TransactionalSystemController : ControllerBase
    {
        private readonly ILogger<TransactionalSystemController> logger;
        private readonly ICardsService cardsService;

        public TransactionalSystemController(ILogger<TransactionalSystemController> _logger, ICardsService _cardsService)
        {
            logger = _logger;
            cardsService = _cardsService;
        }

        [HttpPost("createCard")]
        public async Task<Result<GenericResponse>> CreateCardAsync(GenericRequest request)
        {
            var result = await cardsService.CreateCardSrvAsync(request);
            return result;
        }

        [HttpPost("transaction")]
        public async Task<Result<GenericResponse>> TransactionAsync(TransactionRequest request)
        {
            var result = await cardsService.TransactionSrvAsync(request);
            return result;
        }

        [HttpPost("getBalance")]
        public async Task<Result<GetBalanceResponse>> GetBalanceAsync(GetBalanceRequest request)
        {
            var result = await cardsService.GetBalanceSrvAsync(request);
            return result;
        }
    }
}
