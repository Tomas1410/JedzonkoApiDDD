using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jedzonko.Api.Mappers;
using Jedzonko.Api.Validation;
using Jedzonko.Data.Sql;
using Jedzonko.IServices.Uzytkownik;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Jedzonko.Api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/user")]
    public class Userv2Controller : Controller
    {
        private readonly JedzonkoDbContext _context;
        private readonly IUzytkownikService _uzytkownikService;

        public Userv2Controller(JedzonkoDbContext context, IUzytkownikService uzytkownikService)
        {
            _context = context;
            _uzytkownikService = uzytkownikService;
        }
        
        [HttpGet("name/{userName}",Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _uzytkownikService.GetUserByUserName(userName);
            if(user != null)
            {
                return Ok(UserToUserViewModelMapper.UzytkownicyViewModel(user));
            }
            return NotFound();
        }
        [ValidateModel]

        public async Task<IActionResult> Post([FromBody]IServices.Request.CreateUser createUser)
        {
            var user = await _uzytkownikService.CreateUzytkownik(createUser);

            return Created(user.Id.ToString(), UserToUserViewModelMapper.UzytkownicyViewModel(user));
        }

        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}",Name = "EditUser")]

        public async Task<IActionResult> EditUser([FromBody] IServices.Request.EditUser editUser, int userId)
        {
            await _uzytkownikService.EditUzytkownik(editUser, userId);

            return NoContent();
        }
        [Authorize]
        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _uzytkownikService.GetUserByUserId(userId);
            if (user != null)
            {
                return Ok(UserToUserViewModelMapper.UzytkownicyViewModel(user));
            }
            return NotFound();
        }

        [HttpPost("gettoken")]
        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,"some_id"),
                new Claim("Tomasz","Uryga")
            };


            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);


            //c# representation of the json token
            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audiance,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials
                );

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = tokenJson });
        }




    }

}
