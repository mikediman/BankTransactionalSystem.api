using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;

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
        public async Task<ActionResult<CreateCardResponse>> CreateCardAsync(GenericRequest request)
        {
            var result = await cardsService.CreateCardSrvAsync(request);
            return result;
        }
    }
}
