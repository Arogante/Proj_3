using Domain.ViewModel.Team;
using Microsoft.AspNetCore.Authorization;
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
            if (resp.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(resp.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> GetTeam(int id)
        {
            var resp = await _teamService.GetTeam(id);
            if (resp.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(resp.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteTeam(int id) {
            var resp = await _teamService.DeleteTeam(id);
            if (resp.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(resp.Data);
            }
            return RedirectToAction("Error");
        }
        [Authorize(Roles = "Admin")]// maybe delete if many teams
        [HttpGet]
        public async Task<IActionResult> SaveTeam(int id) {
            if (id == 0) {
                return View();
            }
            var resp=await _teamService.GetTeam(id);
            if (resp.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(resp.Data);
            }
            return RedirectToAction("Error");
        }

        
        [HttpPost]
        public async Task<IActionResult> SaveTeam(TeamViewModel model)
        {
            if (ModelState.IsValid) {
                if (model.Id == 0) {
                    await _teamService.CreateTeam(model);
                }
                else
                {
                    await _teamService.EditTeam(model.Id, model);
                }
            }
            return RedirectToAction("GetTeams");
        }



    }
}
