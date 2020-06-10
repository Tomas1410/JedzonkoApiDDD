using Jedzonko.Data.SQL.DAO;
using Jedzonko.IData.Rodzaj;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.Data.Sql.Rodzaj
{
    public class RodzajRepository:IRodzajRepository
    {
        private readonly JedzonkoDbContext _context;

        public RodzajRepository(JedzonkoDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddRodzaj(Domain.Rodzaj.Rodzaj rodzaj)
        {
            var rodzajDao = new Rodzaje
            {
                Typ = rodzaj.Nazwa
            };

            await _context.AddAsync(rodzajDao);
            await _context.SaveChangesAsync();
            return rodzajDao.RodzajeId;
        
        }



        
    }
}
