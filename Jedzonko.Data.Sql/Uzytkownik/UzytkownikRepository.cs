using Jedzonko.Data.SQL.DAO;
using Jedzonko.IData.Uzytkownik;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.Data.Sql.Uzytkownik
{
    public class UzytkownikRepository : IUzytkownikRepository
    {
        private readonly JedzonkoDbContext _context;

        public UzytkownikRepository(JedzonkoDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUzytkownik(Domain.Uzytkownik.Uzytkownik uzytkownik)
        {
            var uzytkownikDao = new SQL.DAO.Uzytkownicy()
            {
                NazwaUzytkownika = uzytkownik.NazwaUzytkownika,
                Imie = uzytkownik.Imie,
                Nazwisko = uzytkownik.Nazwisko,
                Email = uzytkownik.Email,
                GrupyId=uzytkownik.GrupaId,
                Zablokowany=uzytkownik.Zablokowany
            };
            await _context.AddAsync(uzytkownikDao);
            await _context.SaveChangesAsync();
            return uzytkownikDao.UzytkownicyId;
        }

        public async Task EditUzytkownik(Domain.Uzytkownik.Uzytkownik uzytkownik)
        {
            var editUser = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.UzytkownicyId == uzytkownik.Id);
            editUser.NazwaUzytkownika = uzytkownik.NazwaUzytkownika;
            editUser.Imie = uzytkownik.Imie;
            editUser.Nazwisko = uzytkownik.Nazwisko;
            editUser.Email = uzytkownik.Email;
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Uzytkownik.Uzytkownik> GetUzytkownik(int userId)
        {
            var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.UzytkownicyId == userId);
            return new Domain.Uzytkownik.Uzytkownik(
                uzytkownik.UzytkownicyId,
                uzytkownik.NazwaUzytkownika,
                uzytkownik.Email, 
                uzytkownik.Imie,
                uzytkownik.Nazwisko,
                uzytkownik.GrupyId,
                uzytkownik.Zablokowany);
         
        }

        public async Task<Domain.Uzytkownik.Uzytkownik> GetUzytkownik(string userName)
        {
            var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.NazwaUzytkownika == userName);
            return new Domain.Uzytkownik.Uzytkownik(uzytkownik.UzytkownicyId,
                uzytkownik.NazwaUzytkownika,
                uzytkownik.Imie,
                uzytkownik.Nazwisko,
                uzytkownik.Email,
                uzytkownik.GrupyId,
                uzytkownik.Zablokowany);
        }
    }
}

