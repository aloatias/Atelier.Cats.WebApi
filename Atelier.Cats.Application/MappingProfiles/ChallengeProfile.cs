using Atelier.Cats.Application.Dtos;
using Atelier.Cats.Domain.Entities;
using AutoMapper;

namespace Atelier.Cats.Application.MappingProfiles
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<Challenge, ChallengeDetailsDto>();

            CreateMap<ChallengeCreationDto, Challenge>();
        }
    }
}
