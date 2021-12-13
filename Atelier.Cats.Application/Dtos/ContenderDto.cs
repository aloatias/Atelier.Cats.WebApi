using System;

namespace Atelier.Cats.Application.Dtos
{
    public class ContenderDto
    {
        public Guid Id { get; init; }
        public string AtelierId { get; init; }
        public string Name { get; set; }
        public string Url { get; init; }
    }
}