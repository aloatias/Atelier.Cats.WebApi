using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Application.Extensions;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<CatDto> FindAsync(Guid id)
        {
            var cat = await _unitOfWork.CatRepository.FindAsync(id);
            if (cat is null)
            {
                throw new NotFoundException("The searched cat wasn't found");
            }

            return cat.AsDto();
        }

        public async Task<CatDto> FindAsync(string atelierId)
        {
            var cat = await _unitOfWork.CatRepository.FindAsync(x => x.AtelierId == atelierId);
            if (cat is null)
            {
                throw new NotFoundException("The searched cat wasn't found");
            }

            return cat.AsDto();
        }

        public async Task<ContendersCoupleDto> GetContendersAsync()
        {
            var contendersCouple = await _unitOfWork.CatRepository.GetContendersAsync();
            if (contendersCouple.Item1 is null
                || contendersCouple.Item2 is null)
            {
                throw new NotFoundException("Not enough contenders where found");
            }

            return contendersCouple.AsDto();
        }

        public async Task<IEnumerable<CatDto>> GetWinnersAsync()
        {
            return (await _unitOfWork.CatRepository.GetWinnersAsync()).Select(cat => cat.AsDto());
        }

        public async Task ImportCatsCatalogAsync()
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
        }
    }
}
