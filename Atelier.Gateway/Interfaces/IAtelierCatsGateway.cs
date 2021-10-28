using Atelier.Gateway.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Gateway.Interfaces
{
    public interface IAtelierCatsGateway
    {
        Task<IEnumerable<AtelierCatDto>> GetCatsCatalogAsync();
    }
}
