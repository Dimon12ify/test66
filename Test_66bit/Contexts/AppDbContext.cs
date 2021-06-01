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
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=admin;Password=756E6be3;Pooling=true;");
        }
    }
}