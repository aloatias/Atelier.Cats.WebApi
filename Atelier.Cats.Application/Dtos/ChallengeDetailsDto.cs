using System;

namespace Atelier.Cats.Application.Dtos
{
    public class ChallengeDetailsDto
    {
        public Guid Id { get; init; }
        public Guid WinnerId { get; init; }
        public Guid LoserId { get; init; }
        public DateTime VoteDate { get; init; }
    }
}
