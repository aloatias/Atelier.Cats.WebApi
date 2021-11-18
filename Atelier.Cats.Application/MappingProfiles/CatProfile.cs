using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Domain.Entities;
using AutoMapper;
using Bogus;
using System;
using System.Linq;

namespace Atelier.Cats.Application.MappingProfiles
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            CreateMap<Cat, CatDetailsDto>()
                .AfterMap((_, y) => y.Name = new Faker().Name.FirstName());

            CreateMap<Cat, ContenderDto>()
                .AfterMap((_, y) => y.Name = new Faker().Name.FirstName());
            CreateMap<Tuple<Cat, Cat>, ContendersCoupleDto>()
                .ForMember(x => x.ContenderOne, opt => opt.MapFrom(x => x.Item1))
                .ForMember(x => x.ContenderTwo, opt => opt.MapFrom(x => x.Item2));

            CreateMap<Cat, WinnerDto>()
                .AfterMap((_, y) => y.Name = new Faker().Name.FirstName())
                .AfterMap((x, y) => y.Votes = x.ChallengesWinner?.Count() ?? 0);
        }
    }
}
