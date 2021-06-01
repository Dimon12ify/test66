using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public void Add(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            _context.SaveChanges();
        }

        public void Edit(Footballer footballer)
        {
            /*var oldFootballer = _context.Footballers.FirstOrDefault(f => f.Id == footballerId);
            oldFootballer.Birthday = footballer.Birthday;
            oldFootballer.Country = footballer.Country;
            oldFootballer.Gender = footballer.Gender;
            oldFootballer.Name = footballer.Name;
            oldFootballer.Surname = footballer.Surname;
            oldFootballer.Team = footballer.Team;*/
            _context.Entry(footballer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}