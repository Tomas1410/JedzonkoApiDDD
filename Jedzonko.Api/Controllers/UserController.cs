using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jedzonko.Api.BindingModels;
using Jedzonko.Api.Validation;
using Jedzonko.Api.ViewModels;
using Jedzonko.Data.Sql;
using Jedzonko.Data.SQL.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jedzonko.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly JedzonkoDbContext _context;

        public UserController(JedzonkoDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.UzytkownicyId == userId);
            
            if (user != null)
            {
                return Ok(new UzytkownicyViewModel
                {
                  
                    NazwaUzytkownika = user.NazwaUzytkownika,
                    Imie = user.Imie,
                    Nazwisko = user.Nazwisko,
                    Email = user.Email,
                    Zablokowany= user.Zablokowany
                    
                   
                });
            }
            return NotFound();
        }


        [ValidateModel]
        //        [Consumes("application/x-www-form-urlencoded")]
        //        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new Uzytkownicy
            {
                NazwaUzytkownika = createUser.NazwaUzytkownika,
                Email = createUser.Email,
               
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created(user.UzytkownicyId.ToString(), new UzytkownicyViewModel
            {
                   
                   NazwaUzytkownika = user.NazwaUzytkownika,
                   Imie =  user.Imie,
                   Nazwisko = user.Nazwisko,
                   Email = user.Email,
                   Zablokowany = user.Zablokowany
            });
        }
        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
        //        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.Uzytkownicy.FirstOrDefaultAsync(x => x.UzytkownicyId == userId);
            user.NazwaUzytkownika = editUser.NazwaUzytkownika;
            user.Imie = editUser.Imie;
            user.Nazwisko = editUser.Nazwisko;
            user.Email = editUser.Email;

            await _context.SaveChangesAsync();
            return NoContent();
            /*return Ok(new UzytkownicyViewModel
            {
                
                NazwaUzytkownika = user.NazwaUzytkownika,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Email = user.Email,
                Zablokowany = user.Zablokowany
            });*/
        }
        


    }
}
