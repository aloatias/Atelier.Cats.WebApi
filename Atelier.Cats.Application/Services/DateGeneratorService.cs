using Atelier.Cats.Application.Interfaces;
using System;

namespace Atelier.Cats.Application.Services
{
    public class DateGeneratorService : IDateGeneratorService
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
