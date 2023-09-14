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
        csMusicService _service = new csMusicService();

        //GET: api/music/ReadMusicGroups
        [HttpGet()]
        [ActionName("ReadMusicGroups")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csMusicGroup>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ReadMusicGroups()
        {
            try
            {
                var mg = _service.ReadMusicGroups();
                return Ok(mg);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/music/ReadAlbums
        [HttpGet()]
        [ActionName("ReadAlbums")]
        [ProducesResponseType(200, Type = typeof(List<csAlbum>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ReadAlbums()
        {
            try
            {
                return Ok(_service.ReadAlbums());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/music/ReadAlbums
        [HttpGet()]
        [ActionName("OldestBand")]
        [ProducesResponseType(200, Type = typeof(List<csAlbum>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> OldestBand()
        {
            try
            {
                return Ok(_service.OldestBand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Music/Seed
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string NrOfItems)
        {
            NrOfItems ??= "10";
            try
            {
                int _nrOfItems = int.Parse(NrOfItems);

                var _ret = _service.Seed(_nrOfItems);

                return Ok($"{_ret} groups in total");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

