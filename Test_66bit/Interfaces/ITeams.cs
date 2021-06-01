using System.Collections.Generic;
using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface ITeams
    {
        IEnumerable<Team> All { get; }
        
        IEnumerable<string> AllNames { get; }
        Team GetTeamById(long teamId);

        void Add(Team team);
    }
}