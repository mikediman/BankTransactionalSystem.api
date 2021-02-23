using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BankTransactionalSystem.Types.Requests
{
    [DataContract]
    public class GetBalanceRequest : GenericRequest
    {
        [DataMember(Name = "cardNumber")]
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        [DataMember(Name = "amount")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [DataMember(Name = "transactionType")]
        [JsonPropertyName("transactionType")]
        public string TransactionType { get; set; }
    }
}
