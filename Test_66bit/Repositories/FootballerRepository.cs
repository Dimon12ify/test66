using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Test_66bit.Contexts;
using Test_66bit.Controllers;
using Test_66bit.Interfaces;
using Test_66bit.Models;

namespace Test_66bit.Repositories
{
    public class FootballerRepository : IFootballerRepository
    {
        private readonly AppDbContext _context;
        
        public FootballerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Footballer> All => _context.Footballers.OrderBy(f => f.Id);

        public Footballer GetById(long footballerId) =>
            _context.Footballers.FirstOrDefault(f => f.Id == footballerId);

        public void AddOrEdit(Footballer footballer, FootballerController.ActionType type)
        {
            if (type == FootballerController.ActionType.Add)
                _context.Footballers.Add(footballer);
            else
                _context.Entry(footballer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}