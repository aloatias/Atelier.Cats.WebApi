using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class ChallengeResultDto
    {
        public Guid ChallengerOneId { get; set; }
        public Guid ChallengerTwoId { get; set; }
        public Guid WinnerId { get; set; }
    }
}