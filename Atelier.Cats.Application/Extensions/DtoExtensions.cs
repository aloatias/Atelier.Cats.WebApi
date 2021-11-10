using Atelier.Cats.Contracts;
using Atelier.Cats.Domain.Entities;
using Bogus;
using System;

namespace Atelier.Cats.Application.Extensions
{
    public static class DtoExtensions
    {
        public static CatDto AsDto(this Cat cat)
        {
            return new CatDto
            {
                Id = cat.Id,
                AtelierId = cat.AtelierId,
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

        public static ChallengeDto AsDto(this Challenge challenge)
        {
            return new ChallengeDto
            {
                Id = challenge.Id,
                ChallengerOneId = challenge.ChallengerOneId,
                ChallengerTwoId = challenge.ChallengerTwoId,
                WinnerId = challenge.WinnerId,
                VoteDate = challenge.VoteDate
            };
        }
    }
}
