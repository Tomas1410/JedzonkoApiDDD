using Jedzonko.Common.Enums;
using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Stan
    {
        public Stan()
        {
            Przepisy = new List<Przepisy>();
        }
        public int StanId { get; set; }
        public NazwaStanu NazwaStanu { get; set; }

        public virtual ICollection<Przepisy> Przepisy { get; set; }
    }
}
