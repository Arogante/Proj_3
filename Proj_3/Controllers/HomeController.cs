﻿using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Proj_3.Models;
using System.Diagnostics;

namespace Proj_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Team team_a = new Team() { 
                Name="Team A",
                Description="Команда по разработке решений в сфере ..."
            };
            return View(team_a);

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