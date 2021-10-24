using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class WinnerResultDto
    {
        public string Name { get; set; }
        public Guid WinnerId { get; set; }
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public int Votes { get; set; }
    }
}
