using BankTransactionalSystem.Implementation.Database;
using BankTransactionalSystem.Implementation.Database.Models;
using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Tests.Tests;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;
using BankTransactionalSystem.Types.Result;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BankTransactionalSystem.Tests.CardsServiceTests
{
    public class CardsServiceTest : IClassFixture<BankTransactionalSystemFixture>
    {
        private ICardsService cardsService;
        private readonly TransactionalSystemDbContext dbContext;

        public CardsServiceTest(BankTransactionalSystemFixture fixture)
        {
            cardsService = fixture.Scope.ServiceProvider.GetRequiredService<ICardsService>();
            dbContext = fixture.Scope.ServiceProvider.GetRequiredService<TransactionalSystemDbContext>();
        }

        #region Create Card

        [Fact]
        public async Task<Result<GenericResponse>> CreateCardAsync_Success()
        {
            GenericRequest request = CreateRequest();
            var response = (await cardsService.CreateCardSrvAsync(request));
            Assert.NotNull(response);
            Assert.True(response.Payload.isCreated);
            var savedCard = dbContext.Set<Card>().Where(c => c.CardOwner == request.UserName).SingleOrDefault();
            Assert.NotNull(savedCard);
            return response;
        }

        private GenericRequest CreateRequest()
        {
            GenericRequest request = new GenericRequest();
            request.UserName = "mikediman";
            return request;
        }

        #endregion

        #region Trnsaction

        [Fact]
        public async Task<Result<GenericResponse>> TransactionAsync_Success()
        {
            TransactionRequest request = CreateTransactionRequest();
            var response = (await cardsService.TransactionSrvAsync(request));
            Assert.NotNull(response);
            Assert.True(response.Payload.isCreated);
            return response;
        }

        private TransactionRequest CreateTransactionRequest()
        {
            TransactionRequest request = new TransactionRequest();
            request.UserName = "mikediman";
            request.TransactionType = "1";
            request.Amount = 200;
            return request;
        }

        #endregion

        #region GetBalance


        [Fact]
        public async Task<Result<GetBalanceResponse>> GetBalanceAsync_Success()
        {
            GetBalanceRequest request = CreateGetBalanceRequest();
            var response = (await cardsService.GetBalanceSrvAsync(request));
            Assert.NotNull(response);
            return response;
        }

        private GetBalanceRequest CreateGetBalanceRequest()
        {
            GetBalanceRequest request = new GetBalanceRequest();
            request.UserName = "mikediman";
            request.TransactionType = "1";
            request.CardNumber = "1234567891234567";
            return request;
        }

        #endregion
    }
}
