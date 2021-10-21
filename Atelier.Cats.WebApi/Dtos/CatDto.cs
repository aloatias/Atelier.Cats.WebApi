using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class CatDto
    {
        public Guid Id { get; set; }
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
