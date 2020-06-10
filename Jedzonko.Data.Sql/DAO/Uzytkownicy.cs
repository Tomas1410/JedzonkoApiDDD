using System.Collections.Generic;

namespace Jedzonko.Data.SQL.DAO
{
    public class Uzytkownicy
    {
        public Uzytkownicy()
        {
            Komentarze = new List<Komentarze>();
            Oceny = new List<Oceny>();
            Przepisy = new List<Przepisy>();
        }

        public int UzytkownicyId { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko  { get; set; }
        public string Email { get; set; }
        public int? GrupyId { get; set; }
        public bool Zablokowany { get; set; }

        public virtual Grupy Grupy { get; set; }
        public virtual ICollection<Komentarze> Komentarze { get; set; }
        public virtual ICollection<Oceny> Oceny { get; set; }
        public virtual ICollection<Przepisy> Przepisy { get; set; }
    }
}
