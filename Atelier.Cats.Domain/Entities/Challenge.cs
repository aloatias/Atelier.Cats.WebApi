using System;

namespace Atelier.Cats.Domain.Entities
{
    public class Challenge : AtelierEntityBase
    {
        public Guid WinnerId { get; set; }
        public Cat Winner { get; set; }

        public Guid LoserId { get; set; }
        public Cat Loser { get; set; }

        public DateTime VoteDate { get; set; }
    }
}
