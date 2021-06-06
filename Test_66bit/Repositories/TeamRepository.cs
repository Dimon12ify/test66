using System.Collections.Generic;
using System.Linq;
using Test_66bit.Contexts;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        
        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> All => _context.Teams;

        public IEnumerable<string> AllNames => _context.Teams.Select(f => f.Name);
        public Team GetById(long teamId) => 
            _context.Teams.FirstOrDefault(f => f.Id == teamId);

        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }
    }
}