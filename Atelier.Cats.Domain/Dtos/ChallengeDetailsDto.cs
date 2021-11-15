using System;

namespace Atelier.Cats.Domain.Dtos
{
    public class ChallengeDetailsDto
    {
        public Guid Id { get; set; }
        public Guid ChallengerOneId { get; set; }
        public Guid ChallengerTwoId { get; set; }
        public Guid WinnerId { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
