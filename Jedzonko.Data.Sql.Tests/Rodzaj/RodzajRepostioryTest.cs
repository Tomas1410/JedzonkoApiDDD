using Jedzonko.Data.Sql.Rodzaj;
using Jedzonko.IData.Rodzaj;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jedzonko.Data.Sql.Tests.Rodzaj
{
    public class RodzajRepostioryTest
    {
        public IConfiguration Configuration { get; }
        private JedzonkoDbContext _context;
        private IRodzajRepository _rodzajRepository;

        public RodzajRepostioryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<JedzonkoDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=root;port=3306;database=jedzonko_db;");
            _context = new JedzonkoDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _rodzajRepository = new RodzajRepository(_context);
        }

        [Fact]
        public async Task CreateRodzaj_Returns_Correct_ValuesAsync()
        {
            var rodzaj = new Domain.Rodzaj.Rodzaj("Dania włoskie");

            var rodzajId = await _rodzajRepository.AddRodzaj(rodzaj);

            var createdRodzaj = await _context.Rodzaje.FirstOrDefaultAsync(x => x.RodzajeId == rodzajId);
            Assert.NotNull(createdRodzaj);

            _context.Rodzaje.Remove(createdRodzaj);
            await _context.SaveChangesAsync();


        }



    }
}
