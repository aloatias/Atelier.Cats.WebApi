using Atelier.Gateway.Dtos;
using Atelier.Gateway.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Atelier.Gateway.Services
{
    public class AtelierCatsGateway : IAtelierCatsGateway
    {
        private readonly IUrlFactory _urlFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        public AtelierCatsGateway(
            IUrlFactory urlFactory,
            IHttpClientFactory httpClientFactory)
        {
            _urlFactory = urlFactory;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<AtelierCatDto>> GetCatsCatalogAsync()
        {
            var client =_httpClientFactory.CreateClient();

            _urlFactory.SetCatsCatalogUrl();
            var result = await client.GetStringAsync(_urlFactory.Url);

            var fullResult = JsonSerializer.Deserialize<AtelierCatsCatalogDto>(result);

            return fullResult.CatsCatalog;
        }
    }
}
