using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Application.Interfaces;
using Atelier.Cats.Application.Models;
using Atelier.Cats.Domain.Entities;
using Atelier.Cats.Domain.Repositories;
using Atelier.Gateway.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atelier.Cats.Application.Services
{
    public class CatService : ICatService
    {
        private readonly IAtelierCatsGateway _gateway;
        private readonly IDateProvider _dateProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatService(
            IAtelierCatsGateway gateway,
            IDateProvider dateProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _gateway = gateway;
            _dateProvider = dateProvider;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CatDetailsDto> FindAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new BadRequestException("The searched id cannot be empty");
            }

            var cat = await _unitOfWork.CatRepository.FindAsync(id);
            if (cat is null)
            {
                throw new NotFoundException("The searched cat wasn't found");
            }

            return _mapper.Map<CatDetailsDto>(cat);
        }

        public async Task<CatDetailsDto> FindAsync(string atelierId)
        {
            if (string.IsNullOrWhiteSpace(atelierId))
            {
                throw new BadRequestException("The searched id cannot be empty");
            }

            var cat = await _unitOfWork.CatRepository.FindAsync(x => x.AtelierId == atelierId);
            if (cat is null)
            {
                throw new NotFoundException("The searched cat wasn't found");
            }

            return _mapper.Map<CatDetailsDto>(cat);
        }

        public async Task<ContendersCoupleDto> GetContendersAsync()
        {
            var contendersCouple = await _unitOfWork.CatRepository.GetContendersAsync();
            if (contendersCouple.Item1 is null
                || contendersCouple.Item2 is null)
            {
                throw new NotFoundException("Not enough contenders where found");
            }

            return _mapper.Map<ContendersCoupleDto>(contendersCouple);
        }

        public async Task<IEnumerable<WinnerDto>> GetWinnersAsync()
        {
            return _mapper.Map<IEnumerable<WinnerDto>>(await _unitOfWork.CatRepository.GetWinnersAsync());
        }

        public async Task ImportCatsCatalogAsync()
        {
            var catsCatalog = await _gateway.GetCatsCatalogAsync();

            var catsToAdd = new List<Cat>();
            foreach (var cat in catsCatalog)
            {
                var currentDate = _dateProvider.GetDate();
                catsToAdd.Add(new Cat { AtelierId = cat.AtelierId, Url = cat.Url, CreationDate = currentDate, LastUpdate = currentDate });
            }

            await _unitOfWork.CatRepository.AddAsync(catsToAdd);
            await _unitOfWork.CommitAsync();
        }
    }
}
