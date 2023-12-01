using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GhanbodeWebbApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new YourDbContext(serviceProvider.GetRequiredService<DbContextOption<YourDbContext>>()))
            {
                if (context.FootballPlayers.Any())
                {
                    return;
                }
                context.FootballPlayers.AddRange(
                    new FootballPlayers
                    {
                        Name = "CRISTIANO RONALDO",
                        Nationality = "PORTUGIES",
                        Age ="38",
                        Price = "$170.00M",
                        Description = "He is 187m tall considered the best player in history and the portugal national team captain",

                    },
                      new FootballPlayers
                    {
                        Name = "lIONEL MESSI",
                        Nationality = "ARGENTINIAN",
                        Age ="36",
                        Price = "$200.00M",
                        Description = "He is 170m tall also considered the greatest player in history and captain Argentina to their third world cup ",

                    },
                      new FootballPlayers
                    {
                        Name = "NEYMAR jr",
                        Nationality = "BRAZILIAN",
                        Age ="31",
                        Price = "$222.00M",
                        Description = "He is 175m tall considered as one of the most skillful and elegant player in history of the sport",

                    },
                      new FootballPlayers
                    {
                        Name = "VICTOR OSIMHEN",
                        Nationality = "NIGERIAN",
                        Age ="24",
                        Price = "$150.00M",
                        Description = "He is 186m tall plays for Nigeria National Team (super eagles) and lead Napoli to their first league trophy in 33years",

                    }
                );
                 context.SaveChanges();
            }
        }

    }

}