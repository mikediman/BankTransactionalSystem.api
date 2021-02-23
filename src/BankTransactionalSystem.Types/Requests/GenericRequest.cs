
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BankTransactionalSystem.Types.Requests
{
    [DataContract]
    public class GenericRequest
    {
        [DataMember(Name = "userName")]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}
