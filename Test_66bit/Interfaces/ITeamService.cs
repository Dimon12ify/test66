using Test_66bit.Models;

namespace Test_66bit.Interfaces
{
    public interface ITeamService
    {
        void AddTeam(Team team);
        void AddTeam(string teamName);
        Team GetById(long teamId);
        string GetNameById(long teamId);
        Team GetByName(string name);
    }
}