using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Domain.Rodzaj
{
    public class Rodzaj
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public Rodzaj(string nazwaRodzaju)
        {
            Nazwa = nazwaRodzaju;
        }
    }
}
