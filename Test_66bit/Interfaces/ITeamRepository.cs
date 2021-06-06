using System.Collections.Generic;
using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> All { get; }
        
        IEnumerable<string> AllNames { get; }
        Team GetById(long teamId);

        void Add(Team team);
    }
}