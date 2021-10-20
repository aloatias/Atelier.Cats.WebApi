using System;

namespace Atelier.Cats.DataAccess.Entities
{
    public class Challenge : AtelierEntityBase
    {
        public Guid ChallengerOneId { get; set; }
        public Cat ChallengerOne { get; set; }

        public Guid ChallengerTwoId { get; set; }
        public Cat ChallengerTwo { get; set; }

        public Guid WinnerId { get; set; }
        public Cat Winner { get; set; }

        public DateTime VoteDate { get; set; }
    }
}
