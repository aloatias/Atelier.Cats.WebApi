using System;

namespace Atelier.Cats.Application.Dtos
{
    public class CatDetailsDto
    {
        public Guid Id { get; init; }
        public string AtelierId { get; init; }
        public string Name { get; set; }
        public string Url { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime LastUpdate { get; init; }
    }
}
