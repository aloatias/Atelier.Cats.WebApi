using Atelier.Cats.Application.Interfaces;
using System;

namespace Atelier.Cats.Application.Common
{
    public class DateGenerator : IDateGenerator
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
