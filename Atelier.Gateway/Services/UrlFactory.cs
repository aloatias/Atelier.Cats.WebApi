using Atelier.Gateway.Configuration;
using Atelier.Gateway.Interfaces;
using Microsoft.Extensions.Options;

namespace Atelier.Gateway.Services
{
    public class UrlFactory : IUrlFactory
    {
        private readonly AtelierCatsUrlOptions _options;

        public string Url { get; private set; }

        public UrlFactory(IOptions<AtelierCatsUrlOptions> configuration)
        {
            _options = configuration.Value;
        }

        public void SetCatsCatalogUrl()
        {
            Url = $"{ _options.Base }{ _options.GetCatsCatalog }";
        }
    }
}
