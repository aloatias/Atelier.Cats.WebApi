using Atelier.Cats.Application.Interfaces;
using System;

namespace Atelier.Cats.Application.Common
{
    public class DateProvider : IDateProvider
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
