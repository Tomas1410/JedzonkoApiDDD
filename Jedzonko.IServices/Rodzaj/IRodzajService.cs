using Jedzonko.IServices.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.IServices.Rodzaj
{
    public interface IRodzajService
    {
        Task<Domain.Rodzaj.Rodzaj> AddRodzaj(AddRodzaj addRodzaj);

    }
}
