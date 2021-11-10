using Atelier.Cats.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface ICatService
    {
        Task<CatDetailsDto> FindAsync(Guid id);
        Task<CatDetailsDto> FindAsync(string atelierId);
        Task<ContendersCoupleDto> GetContendersAsync();
        Task<IEnumerable<CatDetailsDto>> GetWinnersAsync();
        Task ImportCatsCatalogAsync();
    }
}
