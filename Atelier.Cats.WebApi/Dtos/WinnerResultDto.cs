using System;

namespace Atelier.Cats.WebApi.Dtos
{
    public class WinnerResultDto
    {
        public Guid WinnerId { get; set; }
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public int Victories { get; set; }
    }
}
