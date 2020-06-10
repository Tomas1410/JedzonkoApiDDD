using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.ViewModels
{
    public class UzytkownicyViewModel
    {
        public string NazwaUzytkownika { get; set; }
        public string Imie { get; set; }
        public string  Nazwisko { get; set; }
        public string Email { get; set; }
        public bool Zablokowany { get; set; }


    }
}
