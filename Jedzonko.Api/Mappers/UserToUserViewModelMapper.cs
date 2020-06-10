using Jedzonko.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
       public static UzytkownicyViewModel UzytkownicyViewModel(Domain.Uzytkownik.Uzytkownik uzytkownik)
        {
            var userViewModel = new UzytkownicyViewModel
            {
                NazwaUzytkownika = uzytkownik.NazwaUzytkownika,
                Imie = uzytkownik.Imie,
                Nazwisko = uzytkownik.Nazwisko,
                Email = uzytkownik.Email,
                Zablokowany = uzytkownik.Zablokowany
            };
            return userViewModel;
        }

    }
}
