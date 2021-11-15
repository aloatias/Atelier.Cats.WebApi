using System;

namespace Atelier.Cats.Domain.Dtos
{
    public class ChallengeCreationDto
    {
        public Guid WinnerId { get; set; }
        public Guid LoserId { get; set; }
    }
}
