using System;
using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Przepisy
    {
       public Przepisy()
        {
            SkladnikiPrzepisow = new List<SkladnikiPrzepisow>();
            Zdjecia = new List<Zdjecia>();
            RodzajePrzepisow = new List<RodzajePrzepisow>();
            Komentarze = new List<Komentarze>();
            Oceny = new List<Oceny>();
            
        }


        public int PrzepisyId { get; set; }
        public int UzytkownicyId { get; set; }
        public string Tytul { get; set; }
        public string SposobWykonania { get; set; }
        public DateTime DataPrzepisu { get; set; }
        public int StanId { get; set; }

        public virtual Stan Stan { get; set; }
        public virtual Uzytkownicy Uzytkownicy { get; set; }

        public virtual ICollection<SkladnikiPrzepisow> SkladnikiPrzepisow { get; set; }
        public virtual ICollection<Zdjecia> Zdjecia { get; set; }
        public virtual ICollection<RodzajePrzepisow> RodzajePrzepisow { get; set; }
        public virtual ICollection<Komentarze> Komentarze { get; set; }
        public virtual ICollection<Oceny> Oceny { get; set; }
     



    }
}
