using System;
using System.Collections.Generic;

namespace Atelier.Cats.Domain.Entities
{
    public class Cat : AtelierEntityBase
    {
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public IEnumerable<Challenge> ChallengesAsContenderOne { get; set; }
        public IEnumerable<Challenge> ChallengesAsContenderTwo { get; set; }
        public IEnumerable<Challenge> ChallengesWinner { get; set; }
    }
}
