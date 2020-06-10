using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jedzonko.Api.Validation;
using Jedzonko.Api.ViewModels;
using Jedzonko.Data.Sql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jedzonko.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ZdjecieController : Controller
    {


        private readonly JedzonkoDbContext _context;

        public ZdjecieController(JedzonkoDbContext context)
        {
            _context = context;
        }

        [ValidateModel]
        [HttpDelete("delete/{zdjeciaId:min(1)}", Name = "GetZdjecieById")]

        public async Task<IActionResult> GetZdjecieById(int zdjeciaId)
        {
            var zdjecie = await _context.Zdjecia.FirstOrDefaultAsync(x => x.ZdjeciaId == zdjeciaId);

            _context.Zdjecia.Remove(zdjecie);
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new ZdjecieViewModel
            {
                ZdjeciaId = zdjecie.ZdjeciaId,
                Imglink = zdjecie.Imglink,
                PrzepisId = zdjecie.PrzepisyId
            });
        }

    }
}
