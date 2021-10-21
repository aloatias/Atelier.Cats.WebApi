using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class ChosenWinnerDto
    {
        public Guid ChallengerOneId { get; set; }
        public Guid ChallengerTwoId { get; set; }
        public Guid WinnerId { get; set; }
    }
}