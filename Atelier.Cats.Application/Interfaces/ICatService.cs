using Atelier.Cats.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Interfaces
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
