using System.Collections.Generic;
using System.Linq;
using Test_66bit.Contexts;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Repositories
{
    public class FootballerRepository : IFootballers
    {
        private readonly AppDbContext _context;
        
        public FootballerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Footballer> All => _context.Footballers;

        public Footballer GetFootballerById(long footballerId) =>
            _context.Footballers.FirstOrDefault(f => f.Id == footballerId);
    }
}