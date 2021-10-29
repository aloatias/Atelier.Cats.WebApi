using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Cats.Services.Abstractions;
using Atelier.Gateway.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Services
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
