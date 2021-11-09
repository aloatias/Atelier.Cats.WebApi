using Atelier.Cats.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface ICatService
    {
        Task<CatDto> FindAsync(Guid id);
        Task<CatDto> FindAsync(string atelierId);
        Task<ContendersCoupleDto> GetContendersAsync();
        Task<IEnumerable<CatDto>> GetWinnersAsync();
        Task ImportCatsCatalogAsync();
    }
}
