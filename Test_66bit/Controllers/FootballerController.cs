using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Controllers
{
    public class FootballerController : Controller
    {
        private readonly IFootballerRepository _footballerRepository;
        private readonly ITeamRepository _teamRepository;

        public FootballerController(IFootballerRepository footballerRepository, ITeamRepository teamRepository)
        {
            _footballerRepository = footballerRepository;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_footballerRepository.All);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var footballer = _footballerRepository.GetById(id);
            ViewBag.Teams = _teamRepository.AllNames.Append("Add Team").ToList();
            ViewData["Title"] = "Edit footballer";
            ViewData["Type"] = "Edit";
            return View("AddOrEdit",footballer);
        }

        [HttpPost]
        public IActionResult Edit(Footballer footballer, string teamName) =>
            AddOrEdit(footballer, teamName, ActionType.Edit);

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _teamRepository.AllNames.Append("Add Team").ToList();
            ViewData["Title"] = "Add footballer";
            ViewData["Type"] = "Add";
            return View("AddOrEdit");
        }
        
        [HttpPost]
        public IActionResult Add(Footballer input, string teamName) => AddOrEdit(input, teamName, ActionType.Add);

        private IActionResult AddOrEdit(Footballer footballer, string teamName, ActionType type)
        {
            if (ModelState.IsValid)
            {  
                if (footballer.Team == "Add Team")
                {
                    if (!_teamRepository.AllNames.Any(f => string.Equals(f, teamName, StringComparison.CurrentCultureIgnoreCase)))
                        _teamRepository.Add(new Team{Name = teamName});
                    footballer.Team = teamName;
                }
                _footballerRepository.AddOrEdit(footballer, type);
                return RedirectToAction("List");
            }
            ViewData["Title"] = type == ActionType.Edit ? "Edit footballer" : "Add footballer";
            return View("AddOrEdit");
        }
        
        public enum ActionType
        {
            Add,
            Edit
        }
    }
}