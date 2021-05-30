using System.Collections.Generic;
using System.Linq;
using Test_66bit.Contexts;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Repositories
{
    public class TeamRepository : ITeams
    {
        private readonly AppDbContext _context;
        
        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> All => _context.Teams;
        public Team GetTeamById(long teamId) => 
            _context.Teams.FirstOrDefault(f => f.Id == teamId);
    }
}