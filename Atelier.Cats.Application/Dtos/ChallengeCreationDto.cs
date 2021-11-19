using System;

namespace Atelier.Cats.Application.Dtos
{
    public class ChallengeCreationDto
    {
        public Guid WinnerId { get; init; }
        public Guid LoserId { get; init; }
    }
}
