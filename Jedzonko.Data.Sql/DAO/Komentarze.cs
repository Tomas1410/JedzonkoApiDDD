using System;

namespace Jedzonko.Data.SQL.DAO
{
    public class Komentarze
    {
        public int KomentarzeId { get; set; }
        public string Tresc { get; set; }
        public int UzytkownicyId { get; set; }
        public int PrzepisyId { get; set; }
        public DateTime DataKomentarza { get; set; }
        public bool Usuniety { get; set; }
        public bool Ukryty { get; set; }

        public virtual Przepisy Przepisy { get; set; }
        public virtual Uzytkownicy Uzytkownicy { get; set; }

    }
}
