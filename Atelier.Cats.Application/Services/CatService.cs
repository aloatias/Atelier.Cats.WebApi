using Atelier.Cats.Application.Abstractions.Models;
using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
{
    public class CatService : ICatService
    {
        private readonly IAtelierCatsGateway _gateway;
        private readonly IDateGeneratorService _dateGeneratorService;
        private readonly IUnitOfWork _unitOfWork;

        public CatService(
            IAtelierCatsGateway gateway,
            IDateGeneratorService dateGeneratorService,
            IUnitOfWork unitOfWork)
        {
            _gateway = gateway;
            _dateGeneratorService = dateGeneratorService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAtelierResponse<Cat>> FindAsync(Guid id)
        {
            var cat = await _unitOfWork.CatRepository.FindAsync(id);
            if (cat is null)
            {
                return new NoContent<Cat>("The searched cat wasn't found");
            }

            return new Ok<Cat>(cat);
        }

        public async Task<IAtelierResponse<Cat>> FindAsync(string atelierId)
        {
            var cat = await _unitOfWork.CatRepository.FindAsync(x => x.AtelierId == atelierId);
            if (cat is null)
            {
                return new NoContent<Cat>("The searched cat wasn't found");
            }

            return new Ok<Cat>(cat);
        }

        public async Task<IAtelierResponse<Tuple<Cat, Cat>>> GetContendersAsync()
        {
            var contenders = await _unitOfWork.CatRepository.GetContendersAsync();
            if (contenders.Item1 is null
                || contenders.Item2 is null)
            {
                return new NoContent<Tuple<Cat, Cat>>("Not enough contenders where found");
            }

            return new Ok<Tuple<Cat, Cat>>(contenders);
        }

        public async Task<IAtelierResponse<IEnumerable<Cat>>> GetWinnersAsync()
        {
            return new Ok<IEnumerable<Cat>>(await _unitOfWork.CatRepository.GetWinnersAsync());
        }

        public async Task<IAtelierResponse> ImportCatsCatalogAsync()
        {
            var catsCatalog = await _gateway.GetCatsCatalogAsync();

            var catsToAdd = new List<Cat>();
            foreach (var cat in catsCatalog)
            {
                var currentDate = _dateGeneratorService.GetDate();
                catsToAdd.Add(new Cat { AtelierId = cat.AtelierId, Url = cat.Url, CreationDate = currentDate, LastUpdate = currentDate });
            }

            await _unitOfWork.CatRepository.AddAsync(catsToAdd);
            await _unitOfWork.CommitAsync();

            return new Ok();
        }
    }
}
