using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Atelier.Gateway.Dtos
{
    public class AtelierCatsCatalogDto
    {
        [JsonPropertyName("images")]
        public IReadOnlyCollection<AtelierCatDto> CatsCatalog{ get; set; }
    }
}