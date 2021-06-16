using System.Collections.Generic;
using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> All();

        IEnumerable<string> AllNames();

        Team GetByName(string name);
        Team GetById(long teamId);

        void Add(Team team);
        void Add(string teamName);
    }
}