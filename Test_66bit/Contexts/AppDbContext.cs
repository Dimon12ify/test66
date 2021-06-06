using Microsoft.EntityFrameworkCore;
using Test_66bit.Models;

namespace Test_66bit.Contexts
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Teams { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            SampleData.Initialize(this);
        }
    }
}