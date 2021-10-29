using System;

namespace Atelier.Cats.Contracts
{
    public class ChallengeResultDto
    {
        public Guid ChallengerOneId { get; set; }
        public Guid ChallengerTwoId { get; set; }
        public Guid WinnerId { get; set; }
    }
}