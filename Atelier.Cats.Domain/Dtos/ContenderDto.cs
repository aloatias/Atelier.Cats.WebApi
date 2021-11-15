using System;

namespace Atelier.Cats.Domain.Dtos
{
    public class ContenderDto
    {
        public Guid Id { get; set; }
        public string AtelierId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}