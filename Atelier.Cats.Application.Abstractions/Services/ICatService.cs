using Atelier.Cats.Application.Abstractions.Models;
using Atelier.Cats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Abstractions.Services
{
    public interface ICatService
    {
        Task<IAtelierResponse<Cat>> FindAsync(Guid id);
        Task<IAtelierResponse<Cat>> FindAsync(string atelierId);
        Task<IAtelierResponse<Tuple<Cat, Cat>>> GetContendersAsync();
        Task<IAtelierResponse<IEnumerable<Cat>>> GetWinnersAsync();
        Task<IAtelierResponse> ImportCatsCatalogAsync();
    }
}
