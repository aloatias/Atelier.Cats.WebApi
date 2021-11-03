using Atelier.Cats.Application.Abstractions.Services;
using System;

namespace Atelier.Cats.Application.Services
{
    public class DateGeneratorService : IDateGeneratorService
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
