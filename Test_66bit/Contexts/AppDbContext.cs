using Microsoft.EntityFrameworkCore;
using Test_66bit.Models;

namespace Test_66bit.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Footballer> Footballers;
        public DbSet<Team> Teams;
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}