using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.IData.Uzytkownik
{
    public interface IUzytkownikRepository
    {
        Task<int> AddUzytkownik(Jedzonko.Domain.Uzytkownik.Uzytkownik uzytkownik);
        Task<Domain.Uzytkownik.Uzytkownik> GetUzytkownik(int userId);
        Task<Domain.Uzytkownik.Uzytkownik> GetUzytkownik(string userName);
        Task EditUzytkownik(Domain.Uzytkownik.Uzytkownik uzytkownik);


    }
}
