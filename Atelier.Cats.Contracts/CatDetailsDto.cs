using System;

namespace Atelier.Cats.Contracts
{
    public class CatDetailsDto
    {
        public Guid Id { get; set; }
        public string AtelierId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Votes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
