using Jedzonko.IServices.Uzytkownik;
using Jedzonko.IData.Uzytkownik;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jedzonko.IServices.Request;

namespace Jedzonko.Services.Uzytkownik
{
    public class UzytkownikService : IUzytkownikService
    {
        private readonly IUzytkownikRepository _uzytkownikRepository;

        public UzytkownikService(IUzytkownikRepository userRepository)
        {
            _uzytkownikRepository = userRepository;
        }

        public async Task<Domain.Uzytkownik.Uzytkownik> CreateUzytkownik(CreateUser createUser)
        {
            var user = new Domain.Uzytkownik.Uzytkownik( createUser.Email, createUser.Imie, createUser.Nazwisko,createUser.UserName);
            user.Id = await _uzytkownikRepository.AddUzytkownik(user);
            return user;
        }

        public async Task EditUzytkownik(EditUser editUser,int userId)
        {
            var user = await _uzytkownikRepository.GetUzytkownik(userId);
            user.EditUzytkownik(editUser.UserName, editUser.Email, editUser.Imie, editUser.Nazwisko);
             await _uzytkownikRepository.EditUzytkownik(user);

        }

        public Task<Domain.Uzytkownik.Uzytkownik> GetUserByUserId(int userId)
        {
            return _uzytkownikRepository.GetUzytkownik(userId);
        }

        public Task<Domain.Uzytkownik.Uzytkownik> GetUserByUserName(string userName)
        {
            return _uzytkownikRepository.GetUzytkownik(userName);
        }



    }
}
