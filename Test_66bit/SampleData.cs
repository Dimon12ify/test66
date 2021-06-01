using System;
using System.Collections.Generic;
using System.Linq;
using Test_66bit.Contexts;
using Test_66bit.Models;

namespace Test_66bit
{
    public static class SampleData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Teams.Any())
            {
                var teams = new List<Team>
                {
                    new Team {Name = "ProTeam"}, new Team {Name = "DreamTeam"}, new Team {Name = "InTeam"}
                };
                context.Teams.AddRange(teams);
            }
            context.SaveChanges();
            
            if (!context.Footballers.Any())
            {
                context.Footballers.Add(
                    new Footballer
                    {
                        Name = "Cristiano",
                        Surname = "Ronaldo",
                        Birthday = DateTime.Parse("2000-01-01"),
                        Country = Country.Italy,
                        Gender = Gender.Male,
                        Team = "ProTeam"
                    });
            }

            context.SaveChanges();
        }
    }
}