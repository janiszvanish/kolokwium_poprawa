using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_poprawa.Controllers
{
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service){
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var t = await _service.GetTeamById(id);
            if(t is null)
                return NotFound("Nie ma takiego zespołu");
            
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMemberToTheTeam(int teamID, int memberID)
        {
            var n = await _service.AddNewMemberToTheTeam(teamID, memberID);
            if(n == 1)
                return NotFound("Nie ma takiego zespołu");
            if(n == 2)
                return NotFound("Nie ma takiego użytkownika");
            if(n == 3)
                return Conflict("Organizacje zespołu i użytkownika są inne");

            return Ok("Udało dodać się użytkownika");
        }
    }
}