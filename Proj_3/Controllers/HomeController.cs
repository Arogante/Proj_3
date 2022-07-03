using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Proj_3.DAL.Interfaces;
using Proj_3.Models;
using System.Diagnostics;

namespace Proj_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        private readonly ITeamRepository _teamRepository;
        public async Task<IActionResult> Index()
        {
            var resp = await _teamRepository.GetAll();
            return View();

        }

        public IActionResult Privacy()
        {
            int test = 9;
            return View(test);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}