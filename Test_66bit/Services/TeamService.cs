using System;
using Test_66bit.Interfaces;
using Test_66bit.Models;
using static System.String;

namespace Test_66bit.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }
        
        public void AddTeam(Team team)
        {
            if (team.Name == Empty)
            {
                throw new ArgumentException("Team name is mandatory");
            }
            if (_repository.GetByName(team.Name) != null)
            {
                throw new ArgumentException("There is already a team with this name");
            }
            _repository.Add(team);
        }

        public void AddTeam(string teamName)
        {
            if (teamName == Empty)
            {
                throw new ArgumentException("Team name is mandatory");
            }
            if (_repository.GetByName(teamName) == null)
                _repository.Add(teamName);
        }

        public Team GetById(long teamId)
        {
            return _repository.GetById(teamId);
        }

        public string GetNameById(long teamId)
        {
            return _repository.GetById(teamId).Name;
        }

        public Team GetByName(string name) => _repository.GetByName(name);
    }
}