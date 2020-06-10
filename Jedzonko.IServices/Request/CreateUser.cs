using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.IServices.Request
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
