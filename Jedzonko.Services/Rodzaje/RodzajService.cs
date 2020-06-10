using Jedzonko.Domain.Rodzaj;
using Jedzonko.IData.Rodzaj;
using Jedzonko.IServices.Request;
using Jedzonko.IServices.Rodzaj;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.Services.Rodzaje
{
    public class RodzajService : IRodzajService
    {
        private readonly IRodzajRepository _rodzajRepository;

        public RodzajService(IRodzajRepository rodzajRepository)
        {
            _rodzajRepository = rodzajRepository;
        }

       public async Task<Rodzaj> AddRodzaj(AddRodzaj addRodzaj)
        {
            var rodzaj = new Domain.Rodzaj.Rodzaj("Obiadek");
            rodzaj.Id = await _rodzajRepository.AddRodzaj(rodzaj);
            return rodzaj;
        }
    }
}
