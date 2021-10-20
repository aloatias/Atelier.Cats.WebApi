using Atelier.Cats.DataAccess.Interfaces;
using System;

namespace Atelier.Cats.DataAccess.Tools
{
    public class DateGenerator : IDateGenerator
    {
        public DateTime GetDate() => DateTime.Now;
    }
}
