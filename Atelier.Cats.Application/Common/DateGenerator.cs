using Atelier.Cats.Application.Abstractions.Services;
using System;

namespace Atelier.Cats.Application.Common
{
    public class DateGenerator : IDateGenerator
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
