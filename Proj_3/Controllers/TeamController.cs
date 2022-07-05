using Microsoft.AspNetCore.Mvc;
using Proj_3.DAL.Interfaces;
using Team.Service.Interfaces;

namespace Proj_3.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async  Task<IActionResult> GetTeams()
        {
            var resp= await _teamService.GetTeams();
            return View(resp.Data);
        }

    }
}
