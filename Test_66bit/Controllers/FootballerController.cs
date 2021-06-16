using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test_66bit.Interfaces;
using Test_66bit.Models;
using Test_66bit.Services;
using static System.String;

namespace Test_66bit.Controllers
{
    public class FootballerController : Controller
    {
        private readonly IFootballerRepository _footballerRepository;
        private readonly ITeamService _teamService;

        public FootballerController(IFootballerRepository footballerRepository, ITeamService teamService)
        {
            _footballerRepository = footballerRepository;
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var footballer = _footballerRepository.GetById(id);
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
            ViewData["Title"] = "Add footballer";
            ViewData["Type"] = "Add";
            return View("AddOrEdit");
        }
        
        [HttpPost]
        public IActionResult Add(Footballer input, string teamName) => AddOrEdit(input, teamName, ActionType.Add);

        private IActionResult AddOrEdit(Footballer footballer, string teamName, ActionType type)
        {
            if (!IsNullOrEmpty(teamName) && ModelState.IsValid)
            {
                _teamService.AddTeam(teamName);
                footballer.TeamId = _teamService.GetByName(teamName).Id;
                _footballerRepository.AddOrEdit(footballer, type);
                return RedirectToAction("List");
            }
            ViewData["Title"] = type == ActionType.Edit ? "Edit footballer" : "Add footballer";
            ViewData["Type"] = type == ActionType.Edit ? "Edit" : "Add";
            return View("AddOrEdit");
        }
        
        public enum ActionType
        {
            Add,
            Edit
        }
    }
}