using System;

namespace Atelier.Cats.Application.Dtos
{
    public class ContenderDto
    {
        public Guid Id { get; set; }
        public string AtelierId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}