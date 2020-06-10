using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.IData.Rodzaj
{
    public interface IRodzajRepository
    {
        Task<int> AddRodzaj(Domain.Rodzaj.Rodzaj rodzaj);
    }
}
