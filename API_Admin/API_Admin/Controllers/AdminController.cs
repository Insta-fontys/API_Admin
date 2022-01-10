using API_Admin.Services;
using API_Admin.Services.Interfaces;
using DataAccesLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminDatabase _database;

        public AdminController(IAdminDatabase database)
        {
            _database = database;
        }

        [HttpGet("fans")]
        public async Task<ActionResult<IList<Fan>>> GetFans()
        {
            var fans = await _database.GetFans();
            return Ok(fans);
        }

        [HttpGet("creators")]
        public async Task<ActionResult<IList<Creator>>> GetCreators()
        {
            var creators = await _database.GetCreators();
            return Ok(creators);
        }

        [HttpDelete("creator")]
        public async Task<bool> DeleteCreator([FromBody] string name)
        {
            if (await _database.DeleteCreatorByName(name))
                return true;
            return false;
        }

        [HttpDelete("fan")]
        public async Task<bool> DeleteFan(string name)
        {
            if (await _database.DeleteFanByName(name))
                return true;
            return false;
        }

        [HttpDelete("post")]
        public async Task<bool> DeletePost(long id)
        {
            if (await _database.DeletePostById(id))
                return true;
            return false;
        }
    }
}
