using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.WebApi.Interfaces;
using Atelier.Gateway.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Services
{
    public class CatService : ICatService
    {
        private readonly IAtelierCatsGateway _gateway;
        private readonly IDateGenerator _dateGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public CatService(
            IAtelierCatsGateway gateway,
            IDateGenerator dateGenerator,
            IUnitOfWork unitOfWork)
        {
            _gateway = gateway;
            _dateGenerator = dateGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task ImportCatsCatalogAsync()
        {
            var catsCatalog = await _gateway.GetCatsCatalogAsync();

            var catsToAdd = new List<Cat>();
            foreach (var cat in catsCatalog)
            {
                var currentDate = _dateGenerator.GetDate();
                catsToAdd.Add(new Cat { AtelierId = cat.AtelierId, Url = cat.Url, CreationDate = currentDate, LastUpdate = currentDate });
            }

            await _unitOfWork.CatRepository.AddAsync(catsToAdd);
            await _unitOfWork.CommitAsync();
        }
    }
}
