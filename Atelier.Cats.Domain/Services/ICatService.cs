using Atelier.Cats.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Domain.Services
{
    public interface ICatService
    {
        Task<CatDetailsDto> FindAsync(Guid id);
        Task<CatDetailsDto> FindAsync(string atelierId);
        Task<ContendersCoupleDto> GetContendersAsync();
        Task<IEnumerable<WinnerDto>> GetWinnersAsync();
        Task ImportCatsCatalogAsync();
    }
}
