using Atelier.Cats.Domain.Dtos;
using Atelier.Cats.Domain.Entities;
using Bogus;
using System;

namespace Atelier.Cats.Application.Extensions
{
    public static class DtoExtensions
    {
        public static CatDetailsDto AsDto(this Cat cat)
        {
            var nameFaker = new Faker();

            return new CatDetailsDto
            {
                Id = cat.Id,
                AtelierId = cat.AtelierId,
                Name = nameFaker.Name.FirstName(),
                Url = cat.Url,
                CreationDate = cat.CreationDate,
                LastUpdate = cat.LastUpdate
            };
        }

        public static ContendersCoupleDto AsDto(this Tuple<Cat, Cat> contendersCouple)
        {
            var nameFaker = new Faker();

            return new ContendersCoupleDto
            {
                ContenderOne = new ContenderDto
                {
                    Id = contendersCouple.Item1.Id,
                    AtelierId = contendersCouple.Item1.AtelierId,
                    Name = nameFaker.Name.FirstName(),
                    Url = contendersCouple.Item1.Url
                },
                ContenderTwo = new ContenderDto
                {
                    Id = contendersCouple.Item2.Id,
                    AtelierId = contendersCouple.Item2.AtelierId,
                    Name = nameFaker.Name.FirstName(),
                    Url = contendersCouple.Item2.Url
                }
            };
        }

        public static ChallengeDetailsDto AsDto(this Challenge challenge)
        {
            return new ChallengeDetailsDto
            {
                Id = challenge.Id,
                WinnerId = challenge.WinnerId,
                LoserId = challenge.LoserId,
                VoteDate = challenge.VoteDate
            };
        }
    }
}
