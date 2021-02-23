using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using BankTransactionalSystem.Implementation.Database;
using BankTransactionalSystem.Interfaces;
using BankTransactionalSystem.Types.Requests;
using BankTransactionalSystem.Types.Responses;
using BankTransactionalSystem.Types.Result;
using BankTransactionalSystem.Types.Result.Constants;
using BankTransactionalSystem.Implementation.Database.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BankTransactionalSystem.Implementation.Wrappers;

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

        #region CreateCard Service

        public async Task<Result<GenericResponse>> CreateCardSrvAsync(GenericRequest request)
        {
            Result<GenericResponse> response = new Result<GenericResponse>();
            Card card = new Card();
            try
            {
                ValidateRequest(request);
                await CheckIfUserExists(request);
                InsertCardInDb(card, request);
                await dbContext.SaveChangesAsync();
                response.Payload = CreateResponse();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                HandleExeptionResult(response, ex.Message);
            }
            return response;
        }

        private void ValidateRequest(GenericRequest request)
        { 
            if(String.IsNullOrWhiteSpace(request.UserName)) throw new Exception("Please enter a valid Username.");
        }

        private async Task CheckIfUserExists(GenericRequest request)
        {
            var card = await dbContext.Set<Card>().Where(c => c.CardOwner == request.UserName).SingleOrDefaultAsync();
            if (card != null) throw new Exception("The user has already registered.");
        }
        private async void InsertCardInDb(Card card, GenericRequest request)
        {
            card = CreateCard(card, request);            
            await dbContext.AddAsync(card);
        }

        private Card CreateCard(Card card, GenericRequest request)
        {
            card.CardId = Guid.NewGuid();
            card.CardNumber = "1234567891234567";
            card.Balance = 2000M;
            card.CardOwner = request.UserName;
            card.TransactionDate = DateTimeOffset.Now.Date;
            return card;
        }

        private GenericResponse CreateResponse()
        {
            GenericResponse response= new GenericResponse();
            response.isCreated = true;
            return response;
        }

        private void HandleExeptionResult(Result<GenericResponse> response, string error)
        {
            response.ErrorMessage = error;
            response.Code = ResultCode.BadRequest;
            response.Payload = new GenericResponse() { isCreated = false };
        }

        #endregion

        #region Transactions Service

        public async Task<Result<GenericResponse>> TransactionSrvAsync(TransactionRequest request)
        {
            Result<GenericResponse> response = new Result<GenericResponse>();
            Card card = new Card();
            Limit limit = new Limit();
            try
            {
                ValidateTransactionRequest(request);
                card = await RetrieveCardFromDb(request);
                await CheckIfTransactionIsAcceptable(card);
                TransactionWrapper wrapper = CreatetransactionWrapper(card, request);
                await InsertTransactionInDb(wrapper, limit);
                await dbContext.SaveChangesAsync();
                response.Payload = CreateResponse();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                HandleExeptionResult(response, ex.Message);
            }
            return response;
        }

        private void ValidateTransactionRequest(TransactionRequest request)
        {
            ValidateRequest(request);
            if (String.IsNullOrWhiteSpace(request.TransactionType)) throw new Exception("Choose a valid transaction method.");
            if (!request.TransactionType.Equals("0") || !request.TransactionType.Equals("1")) throw new Exception("Choose a valid transaction method.");
        }

        private async Task<Card> RetrieveCardFromDb(TransactionRequest request)
        {
            var card = await dbContext.Set<Card>().Where(c => c.CardOwner == request.UserName).SingleOrDefaultAsync();
            if (card == null) throw new Exception("You need to create a card.");
            return card;
        }

        private async Task CheckIfTransactionIsAcceptable(Card card)
        {
            var consumed = 0M;
            List<Limit> limit = await dbContext.Set<Limit>().Where(c => c.CardNumber == card.CardNumber).ToListAsync();
            if (limit.Count > 0)
            {
                foreach (Limit value in limit)
                {
                    if (value.TransactionDate == DateTimeOffset.Now.Date) consumed += value.Amount;
                    else continue;
                }
            }            
            if (consumed > 2000) throw new Exception("You have exceeded the daily limit.");
        }

        private TransactionWrapper CreatetransactionWrapper(Card card, TransactionRequest request)
        {
            TransactionWrapper wrapper = new TransactionWrapper();
            wrapper.card = card;
            wrapper.request = request;
            return wrapper;
        }

        private async Task InsertTransactionInDb(TransactionWrapper wrapper, Limit limit)
        {
            limit = CreateTransaction(wrapper, limit);
            await dbContext.AddAsync(limit);
        }

        private Limit CreateTransaction(TransactionWrapper wrapper, Limit limit)
        {
            limit.CardNumber = wrapper.card.CardNumber;
            limit.TransactionCategory = wrapper.request.TransactionType;
            limit.LimitId = Guid.NewGuid();
            limit.TransactionDate = DateTimeOffset.Now.Date;
            limit.Amount = wrapper.request.Amount;
            return limit;
        }

        #endregion

        #region Get daily Balance

        public async Task<Result<GetBalanceResponse>> GetBalanceSrvAsync(GetBalanceRequest request)
        {
            Result<GetBalanceResponse> result = new Result<GetBalanceResponse>();
            GetBalanceResponse response = new GetBalanceResponse();
            List<Limit> limit = new List<Limit>();
            try
            {
                ValidategetBalanceRequest(request);
                limit = await RetrieveLimitFromDb(request);
                response = CreateGetBalanceResponse(response, limit);
                result.Payload = response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                GetExeptionResult(result, ex.Message);
            }
            return result;
        }

        private void ValidategetBalanceRequest(GetBalanceRequest request)
        {
            ValidateRequest(request);
            if (String.IsNullOrWhiteSpace(request.TransactionType)) throw new Exception("Choose a valid transaction method.");
            if (!request.TransactionType.Equals("0") || !request.TransactionType.Equals("1")) throw new Exception("Choose a valid transaction method.");
            if (String.IsNullOrWhiteSpace(request.CardNumber)) throw new Exception("Choose a card number.");
        }

        private async Task<List<Limit>> RetrieveLimitFromDb(GetBalanceRequest request)
        {
            List<Limit> limit = await dbContext.Set<Limit>().Where(c => c.CardNumber == request.CardNumber).ToListAsync();
            return limit;
        }

        private GetBalanceResponse CreateGetBalanceResponse(GetBalanceResponse response, List<Limit> limit)
        {
            foreach (Limit value in limit)
            {
                if (value.TransactionCategory == "1" && value.TransactionDate == DateTimeOffset.Now.Date) response.Ecommerce += value.Amount;
                if (value.TransactionCategory == "0" && value.TransactionDate == DateTimeOffset.Now.Date) response.CardPresent += value.Amount;
            }
            return response;
        }

        private void GetExeptionResult(Result<GetBalanceResponse> response, string error)
        {
            response.ErrorMessage = error;
            response.Code = ResultCode.BadRequest;
        }
        #endregion
    }
}
