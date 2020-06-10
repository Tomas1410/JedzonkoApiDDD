using Jedzonko.Domain.DomainExceptions;
using Jedzonko.IData.Uzytkownik;
using Jedzonko.IServices.Request;
using Jedzonko.IServices.Uzytkownik;
using Jedzonko.Services.Uzytkownik;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Jedzonko.Services.Tests
{
    public class UserServiceTest
    {
        private readonly IUzytkownikService uzytkownikService;
        private readonly Mock<IUzytkownikRepository> _userRepositoryMock;

        public UserServiceTest()
        {

            //Arrange
            _userRepositoryMock = new Mock<IUzytkownikRepository>();
            uzytkownikService = new UzytkownikService(_userRepositoryMock.Object);

        }
        
        [Fact]
        public void CreateUser_Returns_LackOfUserNameException()
        {
            var user = new CreateUser
            {
                UserName = "",
                Email = "nowyEmail@wp.pl",
                Imie = "Kacper",
                Nazwisko = "Kowalski"
            };

            Assert.ThrowsAsync<LackOfUserNameException>(() => uzytkownikService.CreateUzytkownik(user));
        }
        
        [Fact]
        public void CreateUser_Returns_Correct_Values()
        {
            var user = new CreateUser { UserName= "UserElegancki",Nazwisko= "Fajna",Email= "slonecznik@wp.pl",Imie= "Martyna" };

            int expectedInteger = 0;
            _userRepositoryMock.Setup(x => x.AddUzytkownik(
                new Domain.Uzytkownik.Uzytkownik
                (
                    user.Email,user.Imie,user.Nazwisko,user.Nazwisko
                
                ))).Returns(Task.FromResult(expectedInteger));
         }



    }
}
