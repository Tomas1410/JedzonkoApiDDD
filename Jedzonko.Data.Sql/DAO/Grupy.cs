using Jedzonko.Common.Enums;
using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Grupy
    {
        public Grupy()
        {
            Uzytkownicy = new List<Uzytkownicy>();
        }
        public int? GrupyId { get; set; }
        public TypGrupy TypGrupy { get; set; }
        public virtual ICollection<Uzytkownicy> Uzytkownicy { get; set; }

    }
}
