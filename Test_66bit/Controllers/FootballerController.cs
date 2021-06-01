using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Controllers
{
    public class FootballerController : Controller
    {
        private readonly IFootballers _footballers;
        private readonly ITeams _teams;

        public FootballerController(IFootballers footballers, ITeams teams)
        {
            _footballers = footballers;
            _teams = teams;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_footballers.All);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var footballer = _footballers.GetFootballerById(id);
            ViewBag.Teams = _teams.AllNames.Append("Add Team").ToList();
            return View(footballer);
        }

        [HttpPost]
        public IActionResult Edit(Footballer footballer, string teamName)
        {
            if (ModelState.IsValid)
            {
                if (footballer.Team == "Add Team")
                {
                    if (!_teams.AllNames.Any(f =>
                        string.Equals(f, teamName, StringComparison.CurrentCultureIgnoreCase)) && teamName.Trim() != "")
                    {
                        _teams.Add(new Team {Name = teamName});
                    }
                    footballer.Team = teamName;
                }
                _footballers.Edit(footballer);
            }
            return RedirectToAction("List");
        }
                
        [HttpGet] 
        public IActionResult Post()
        {
            ViewBag.Teams = _teams.AllNames.Append("Add Team").ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Post(Footballer input, string teamName)
        {
            if (ModelState.IsValid)
            {  
                if (input.Team == "Add Team")
                {
                    if (!_teams.AllNames.Any(f => string.Equals(f, teamName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        _teams.Add(new Team{Name = teamName});
                    }
                    input.Team = teamName;
                }
                _footballers.Add(input);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}