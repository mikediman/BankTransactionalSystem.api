using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BankTransactionalSystem.Types.Responses
{
    [DataContract]
    public class GenericResponse
    {
        [DataMember(Name = "isCreated")]
        [JsonPropertyName("isCreated")]
        public bool isCreated { get; set; }
    }
}
