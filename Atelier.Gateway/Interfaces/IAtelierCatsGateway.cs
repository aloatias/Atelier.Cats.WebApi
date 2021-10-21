using Atelier.Gateway.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Gateway.Interfaces
{
    public interface IAtelierCatsGateway
    {
        Task<IReadOnlyCollection<AtelierCatDto>> GetCatsCatalogAsync();
    }
}
