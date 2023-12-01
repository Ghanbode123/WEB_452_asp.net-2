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
            using (var context = new GhanbodeWebbAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<GhanbodeWebbAppContext>>()))
            {
                // Look for any Playstations.
                if (context.Playstations.Any())
                {
                    return; // DB has been seeded
                }

                context.Playstations.AddRange(
                    new Playstation
                    {
                        ModelName = "PS5",
                        Manufacturer = "Sony",
                        StorageCapacityGB = 825,
                        Price = 499.99M,
                        ReleaseDate = DateTime.Parse("2020-11-12")
                    },

                    new Playstation
                    {
                        ModelName = "PS4",
                        Manufacturer = "Sony",
                        StorageCapacityGB = 500,
                        Price = 299.99M,
                        ReleaseDate = DateTime.Parse("2013-11-15")
                    },

                    new Playstation
                    {
                        ModelName = "Xbox Series X",
                        Manufacturer = "Microsoft",
                        StorageCapacityGB = 1000,
                        Price = 499.99M,
                        ReleaseDate = DateTime.Parse("2020-11-10")
                    },

                    new Playstation
                    {
                        ModelName = "Nintendo Switch",
                        Manufacturer = "Nintendo",
                        StorageCapacityGB = 32,
                        Price = 299.99M,
                        ReleaseDate = DateTime.Parse("2017-03-03")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}