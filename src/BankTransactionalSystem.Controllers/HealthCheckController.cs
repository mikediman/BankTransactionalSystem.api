using BankTransactionalSystem.Types.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankTransactionalSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController() { }

        [HttpGet]
        public IActionResult HealthCheck(GenericRequest request)
        {
            return Content("Hi " + request.UserName + ". Welcome to Bank Transactional System API. The ASP.NET Core Api is running!");
        }
    }
}
