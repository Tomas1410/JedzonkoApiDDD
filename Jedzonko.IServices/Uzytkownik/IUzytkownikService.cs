using Jedzonko.IServices.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jedzonko.IServices.Uzytkownik
{
    public interface IUzytkownikService
    {
        Task<Jedzonko.Domain.Uzytkownik.Uzytkownik> GetUserByUserId(int userId);
        Task<Jedzonko.Domain.Uzytkownik.Uzytkownik> GetUserByUserName(string userName);
        Task<Jedzonko.Domain.Uzytkownik.Uzytkownik> CreateUzytkownik(CreateUser createUser);
        Task EditUzytkownik(EditUser editUser, int userId);


    }
}
