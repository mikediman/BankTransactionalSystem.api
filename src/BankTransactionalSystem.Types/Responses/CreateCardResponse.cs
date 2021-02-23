using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BankTransactionalSystem.Types.Responses
{
    public class CreateCardResponse
    {
        [DataMember(Name = "isCreated")]
        [JsonPropertyName("isCreated")]
        public bool IsRegistered { get; set; }
    }
}
