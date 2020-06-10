using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.IServices.Request
{
    public class AddRodzaj
    {
        public AddRodzaj(string rodzaj)
        {
            Nazwa = rodzaj;
        }

        public string Nazwa { get; set; }


    }
}
