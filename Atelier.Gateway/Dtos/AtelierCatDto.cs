using System.Text.Json.Serialization;

namespace Atelier.Gateway.Dtos
{
    public class AtelierCatDto
    {
        [JsonPropertyName("id")]
        public string AtelierId { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}