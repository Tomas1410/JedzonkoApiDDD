using Jedzonko.Common.Enums;
using Jedzonko.Common.Extensions;
using Jedzonko.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jedzonko.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly JedzonkoDbContext _context;

        public DatabaseSeed(JedzonkoDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var grupyList = BuildGrupyList();
            _context.Grupy.AddRange(grupyList);
            _context.SaveChanges();

            var stanList = BuildStanList();
            _context.Stan.AddRange(stanList);
            _context.SaveChanges();

            var rodzajeList = BuildRodzajeList();
            _context.Rodzaje.AddRange(rodzajeList);
            _context.SaveChanges();

            var skladnikiList = BuildSkladnikiList();
            _context.Skladniki.AddRange(skladnikiList);
            _context.SaveChanges();

            var uzytkownicyList = BuildUzytkownicyList();
            _context.Uzytkownicy.AddRange(uzytkownicyList);
            _context.SaveChanges();

            var przepisyList = BuildPrzepisyList(uzytkownicyList, stanList);
            _context.Przepisy.AddRange(przepisyList);
            _context.SaveChanges();

             var zdjeciaList = BuildZdjeciaList(przepisyList);
             _context.Zdjecia.AddRange(zdjeciaList);
             _context.SaveChanges();

             var rodzajePrzepisowList = BuildRodzajePrzepisowList(przepisyList, rodzajeList);
             _context.RodzajePrzepisow.AddRange(rodzajePrzepisowList);
             _context.SaveChanges();

             var skladnikiPrzepisowList = BuildSkladnikiPrzepisowList(przepisyList, skladnikiList);
             _context.SkladnikiPrzepisow.AddRange(skladnikiPrzepisowList);
             _context.SaveChanges();

             var ocenyList = BuildOcenyList(przepisyList, uzytkownicyList);
             _context.Oceny.AddRange(ocenyList);
             _context.SaveChanges();

             var komentarzeList = BuildKomentarzeList(przepisyList, uzytkownicyList);
             _context.Komentarze.AddRange(komentarzeList);
             _context.SaveChanges();
 

        }

        private IEnumerable<Grupy> BuildGrupyList()
        {
            var grupyList = new List<Grupy>
            {
                new Grupy
                {
                    TypGrupy=TypGrupy.Administrator
                },
                  new Grupy
                {
                    TypGrupy=TypGrupy.Moderator
                },
                    new Grupy
                {
                    TypGrupy=TypGrupy.Uzytkownik
                }
            };
            return grupyList;
        }
        private IEnumerable<Stan> BuildStanList()
        {
            var stanList = new List<Stan>();
            var stan = new Stan()
            {
                NazwaStanu = NazwaStanu.Oczekujacy
            };

            stanList.Add(stan);
            stan = new Stan()
            {
                NazwaStanu = NazwaStanu.Odrzucony
            };
            stanList.Add(stan);
            stan = new Stan()
            {
                NazwaStanu = NazwaStanu.Przyjety
            };
            stanList.Add(stan);
            stan = new Stan()
            {
                NazwaStanu = NazwaStanu.Usuniety
            };
            stanList.Add(stan);
            stan = new Stan()
            {
                NazwaStanu = NazwaStanu.Zmodyfikowany
            };
            stanList.Add(stan);

            return stanList;
        }
        private IEnumerable<Rodzaje> BuildRodzajeList()
        {
            var rodzajeList = new List<Rodzaje> {

                new Rodzaje
                {
                    Typ="Obiad",
                },
                new Rodzaje
                {
                    Typ="Kolacja",
                },
                new Rodzaje
                {
                    Typ="Szybkie",
                },
                new Rodzaje
                {
                    Typ="Desery",
                },
                new Rodzaje
                {
                    Typ="Śniadanie",
                },


            };



            return rodzajeList;
        }
        private IEnumerable<Skladniki> BuildSkladnikiList()
        {

            var skladnikiList = new List<Skladniki>
            {
                new Skladniki
                {
                    Nazwa="makaron swiderki"
                },
                new Skladniki
                {
                    Nazwa="Rosol z kury Knorr"
                },
                new Skladniki
                {
                    Nazwa="filet z kurczaka"
                },
                new Skladniki
                {
                    Nazwa="cebula"
                },
                new Skladniki
                {
                    Nazwa="papryka"
                },
                new Skladniki
                {
                    Nazwa="pomidor"
                },
                new Skladniki
                {
                    Nazwa="przecier pomidorowy"
                },
                new Skladniki
                {
                    Nazwa="ząbek czosnku"
                },
                new Skladniki
                {
                    Nazwa="mozarella light"
                },
                new Skladniki
                {
                    Nazwa="olej"
                }

            };

            return skladnikiList;
        }
        private IEnumerable<Uzytkownicy> BuildUzytkownicyList()
        {

            var listaImion = new List<string>
            {
                 "Andrzej","Marek","Tomek","Agata","Kamila","Agnieszka","Kasia","Zenek","Kacper","Cyprian"
            };
            var listaNazwisk = new List<string>
            {
                 "Kowalski","Nowak","Jurkiewicz","Wasiak","Wisniewski","Uryga","Indziniak","Pandemik","Fajniutki","Paprotka"
            };

            var uzytkownicyList = new List<Uzytkownicy>();
            var random = new Random();


            for (int i = 0; i < 7; i++)
            {
                var index = random.Next(listaImion.Count);
                

                var user = new Uzytkownicy()
                {


                    NazwaUzytkownika = "uzytkownik" + i,
                    Imie = listaImion[index],
                    Nazwisko = listaNazwisk[index],
                    Email = "uzytkownik" + i + "@student.po.edu.pl",
                    GrupyId = 3,
                    Zablokowany = false
                };
                uzytkownicyList.Add(user);
                listaImion.Shuffle();
                listaNazwisk.Shuffle();
                
            }

            for (int i = 0; i < 3; i++)
            {
                var index = random.Next(listaImion.Count);


                var user = new Uzytkownicy()
                {


                    NazwaUzytkownika = "uzytkownik" + i,
                    Imie = listaImion[index],
                    Nazwisko = listaNazwisk[index],
                    Email = "uzytkownik" + i + "@student.po.edu.pl",
                    GrupyId = 2,
                    Zablokowany = false
                };
                uzytkownicyList.Add(user);
                listaImion.Shuffle();
                listaNazwisk.Shuffle();

            }
            var uzytkownik = new Uzytkownicy()
            {
                NazwaUzytkownika = "Włodarz",
                Imie = "Tomasz",
                Nazwisko = "Uryga",
                Email = "t.uryga@student.po.edu.pl",
                GrupyId = 1,
                Zablokowany = false
            };
            uzytkownicyList.Add(uzytkownik);


            return uzytkownicyList;
        }
        private IEnumerable<Przepisy> BuildPrzepisyList(IEnumerable<Uzytkownicy> uzytkownicyList, IEnumerable<Stan> stanList)
        {

            var przepisyList = new List<Przepisy>();
            var rand = new Random();
           
            for (int i = 0; i < 10; i++)
            {

                var przepis = new Przepisy
                {
                    UzytkownicyId = rand.Next(1, uzytkownicyList.Count()),
                    Tytul = i + "lorem ipsum",
                    SposobWykonania = i + "Sposob wykonania przepisu ",
                    DataPrzepisu = DateTime.Now,
                    StanId = rand.Next(1, stanList.Count())
                };
                przepisyList.Add(przepis);
            }



            return przepisyList;
        }
        private IEnumerable<Zdjecia> BuildZdjeciaList(IEnumerable<Przepisy> przepisyList)
        {

            var zdjeciaList = new List<Zdjecia>();
            var rand = new Random();

            for (int i = 1; i < 21; i++)
            {

                var zdjecie = new Zdjecia
                {
                    Imglink="img/przepisy/zdjecie"+i+".jpg",
                    PrzepisyId=rand.Next(1,przepisyList.Count())
                };
                zdjeciaList.Add(zdjecie);
            }


            return zdjeciaList;
       }
        private IEnumerable<RodzajePrzepisow> BuildRodzajePrzepisowList(IEnumerable<Przepisy> przepisyList, IEnumerable<Rodzaje> rodzajeList)
        {
            var rodzajePrzepisowList = new List<RodzajePrzepisow>();
            
            var rand = new Random();

            for (int i = 0; i < 30; i++)
            {

                var RodzajPrzepisu = new RodzajePrzepisow
                {
                    PrzepisyId=rand.Next(1,przepisyList.Count()),
                    RodzajeId=rand.Next(1,rodzajeList.Count())
                };
                rodzajePrzepisowList.Add(RodzajPrzepisu);
            }




            return rodzajePrzepisowList;
        }
        private IEnumerable<SkladnikiPrzepisow> BuildSkladnikiPrzepisowList(IEnumerable<Przepisy> przepisyList, IEnumerable<Skladniki> skladnikiList)
         {

            var skladnikiPrzepisowList = new List<SkladnikiPrzepisow>();
            var rand = new Random();
            
            for (int i = 0; i < 30; i++)
            {

                var SkladnikiPrzepisu = new SkladnikiPrzepisow
                {
                    PrzepisyId=rand.Next(1,przepisyList.Count()),
                    SkladnikiId= rand.Next(1, skladnikiList.Count()),
                    Jednostka = (Jednostka)rand.Next(1, Enum.GetNames(typeof(Jednostka)).Length),
                    Ilosc=rand.Next(1,20)  
                };
                skladnikiPrzepisowList.Add(SkladnikiPrzepisu);
            }



            return skladnikiPrzepisowList;
         }
        private IEnumerable<Oceny> BuildOcenyList(IEnumerable<Przepisy> przepisyList, IEnumerable<Uzytkownicy> uzytkownicyList)
         {

            var ocenyList = new List<Oceny>();

            var rand = new Random();

            for (int i = 0; i < 30; i++)
            {

                var Ocena = new Oceny
                {
                   UzytkownicyId = rand.Next(1, uzytkownicyList.Count()),
                   PrzepisyId = rand.Next(1, przepisyList.Count()),
                   TypOcen= (TypOcen)rand.Next(1, Enum.GetNames(typeof(TypOcen)).Length)

                };
                ocenyList.Add(Ocena);
            }



            return ocenyList;
         }
        private IEnumerable<Komentarze> BuildKomentarzeList(IEnumerable<Przepisy> przepisyList, IEnumerable<Uzytkownicy> uzytkownicyList)
         {

            var komentarzeList = new List<Komentarze>();
            var rand = new Random();

            for (int i = 1; i < 31; i++)
            {

                var Komentarz = new Komentarze
                {
                    Tresc=i+"Tutaj jest tresc komentarza",
                    UzytkownicyId= rand.Next(1, uzytkownicyList.Count()),
                    PrzepisyId = rand.Next(1, przepisyList.Count()),
                    DataKomentarza = DateTime.Now,
                    Ukryty=false,
                    Usuniety=false,
                    
                    

                };
                komentarzeList.Add(Komentarz);
            }

            return komentarzeList;
         }

    }
}
