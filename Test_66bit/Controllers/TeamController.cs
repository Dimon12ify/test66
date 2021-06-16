using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly IFootballerRepository _footballerRepository;
        private readonly ITeamRepository _teamRepository;

        public TeamController(IFootballerRepository footballerRepository, ITeamRepository teamRepository)
        {
            _footballerRepository = footballerRepository;
            _teamRepository = teamRepository;
        }
        
        public Team GetTeamById(long teamId) => _teamRepository.GetById(teamId);

        public IEnumerable<string> GetTeamNames() => _teamRepository.AllNames().ToList();

        public IEnumerable<string> All() => _teamRepository.AllNames().ToList();
    }
}