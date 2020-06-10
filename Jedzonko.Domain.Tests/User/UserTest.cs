
using Jedzonko.Domain.DomainExceptions;
using System;
using Xunit;

namespace Jedzonko.Domain.Tests
{
    public class UserTest
    {
        [Fact]
        public void CreateUser_Returns_Correct_Values()
        {
            var user = new Domain.Uzytkownik.Uzytkownik("slonecznik@wp.pl","Martyna","Fajna", "UserElegancki");

            Assert.Equal("UserElegancki", user.NazwaUzytkownika);
            Assert.Equal("slonecznik@wp.pl", user.Email);
            Assert.Equal("Martyna", user.Imie);
            Assert.Equal("Fajna", user.Nazwisko);
        }
        
        [Fact]
        public void CreateUser_Returns_LackOfUserNameException()
        {
                 Assert.Throws<LackOfUserNameException>(() =>
                 new Domain.Uzytkownik.Uzytkownik("slonecznik@wp.pl", "Martyna", "Fajna",""));

        }
    
    
    }
}
