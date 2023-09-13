using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Configuration;
using Models;
using Models.DTO;

using Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using DbContext;
using DbModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MusicController : Controller
    {
        //GET: api/addresses/read
        [HttpGet()]
        [ActionName("Read")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csMusicGroup>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Read()
        {
            try
            {
                using (var db = csMainDbContext.DbContext("sysadmin"))
                {
                    var mg = db.MusicGroups.ToList();
                    return Ok(mg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/addresses/read
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed()
        {
            try
            {
                var sgen = new csSeedGenerator();
                using (var db = csMainDbContext.DbContext("sysadmin"))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var mg = new csMusicGroup().Seed(sgen);
                        var al = new csAlbum().Seed(sgen);

                        mg.Albums.Add(al);

                        db.MusicGroups.Add(mg);
                    }

                    db.SaveChanges();
                }

                return Ok("1000 groups seeded");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

