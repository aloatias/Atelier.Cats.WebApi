﻿using System;

namespace Atelier.Cats.Domain.Dtos
{
    public class ChallengeDetailsDto
    {
        public Guid Id { get; set; }
        public Guid WinnerId { get; set; }
        public Guid LoserId { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
