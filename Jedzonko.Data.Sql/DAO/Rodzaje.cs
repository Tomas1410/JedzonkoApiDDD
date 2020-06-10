using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Rodzaje
    {
        public Rodzaje()
        {
            RodzajePrzepisow = new List<RodzajePrzepisow>();
        }

        public int RodzajeId { get; set; }
        public string Typ { get; set; }

        public virtual ICollection<RodzajePrzepisow> RodzajePrzepisow { get; set; }
    }
}
