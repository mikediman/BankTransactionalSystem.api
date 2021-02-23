using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankTransactionalSystem.Types.Requests
{
    [DataContract]
    public class TransactionRequest : GenericRequest
    {
        [DataMember(Name = "transactionType")]
        [JsonPropertyName("transactionType")]
        public string TransactionType { get; set; }

        [DataMember(Name = "amount")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [DataMember(Name = "transactionDate")]
        [JsonPropertyName("transactionDate")]
        public string TransactionDate { get; set; }
    }
}
