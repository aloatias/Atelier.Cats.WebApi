using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class ChallengeDto
    {
        public Guid Id { get; set; }
        public Guid ChallengerOneId { get; set; }
        public Guid ChallengerTwoId { get; set; }
        public Guid WinnerId { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
