using Jedzonko.Domain.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Domain.Uzytkownik
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int? GrupaId { get; set; }
        public bool Zablokowany { get; set; }

        public Uzytkownik( string email, string imie, string nazwisko, string nazwa)
        {
            if (nazwa.Length==0)
            {
                throw new LackOfUserNameException(nazwa);
            }
            NazwaUzytkownika =nazwa ;
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            GrupaId = 3;
            Zablokowany = false;
         }
        public Uzytkownik(int id,string nazwa, string email, string imie, string nazwisko,int? grupa,bool zablokowany)
        {
            Id = id;
            NazwaUzytkownika = nazwa;
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            GrupaId = grupa;
            Zablokowany = zablokowany;
        }
        public void EditUzytkownik(string username, string email, string imie, string nazwisko)
        {
           
            NazwaUzytkownika = username;
            Email = email;
            Imie = imie;
            Nazwisko = nazwisko;
        }



    }
}
