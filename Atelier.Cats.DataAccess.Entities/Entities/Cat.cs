using System;

namespace Atelier.Cats.DataAccess.Entities
{
    public class Cat : AtelierEntityBase
    {
        public string AtelierId { get; set; }
        public string Url { get; set; }
        public DateTime Creation { get; set; }
    }
}
