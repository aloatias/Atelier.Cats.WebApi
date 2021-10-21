using System;
using System.Collections.Generic;

namespace Atelier.Cats.DataAccess.Entities
{
    public class Cat : AtelierEntityBase
    {
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public IReadOnlyCollection<Challenge> ChallengesAsContenderOne { get; set; }
        public IReadOnlyCollection<Challenge> ChallengesAsContenderTwo { get; set; }
        public IReadOnlyCollection<Challenge> ChallengesWinner { get; set; }
    }
}
