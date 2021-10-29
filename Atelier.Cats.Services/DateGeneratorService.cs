using Atelier.Cats.Services.Abstractions;
using System;

namespace Atelier.Cats.Services
{
    public class DateGeneratorService : IDateGeneratorService
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
