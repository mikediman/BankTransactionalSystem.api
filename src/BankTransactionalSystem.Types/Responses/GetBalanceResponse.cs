using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BankTransactionalSystem.Types.Responses
{
    [DataContract]
    public class GetBalanceResponse
    {
        [DataMember(Name = "ecommerce")]
        [JsonPropertyName("ecommerce")]
        public decimal Ecommerce { get; set; }

        [DataMember(Name = "cardPresent")]
        [JsonPropertyName("cardPresent")]
        public decimal CardPresent { get; set; }
    }
}
