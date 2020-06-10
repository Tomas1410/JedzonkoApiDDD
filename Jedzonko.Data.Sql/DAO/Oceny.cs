using Jedzonko.Common.Enums;

namespace Jedzonko.Data.SQL.DAO
{
    public class Oceny
    {

        public int OcenyId { get; set; }
        public TypOcen TypOcen { get; set; }
        public int UzytkownicyId { get; set; }
        public int PrzepisyId { get; set; }
        public virtual Uzytkownicy Uzytkownicy { get; set; }
        public virtual Przepisy Przepisy { get; set; }

    }
}
