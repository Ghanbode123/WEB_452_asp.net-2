using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace MvcPlaystations.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcPlaystationsContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcPlaystationsContext>>()))
            {
                // Look for any Playstations.
                if (context.Playstations.Any())
                {
                    return; // DB has been seeded
                }

                context.Playstations.AddRange(
                    new Playstations
                    {
                        ModelName = "PS5",
                        Manufacturer = "Sony",
                        StorageCapacityGB = 825,
                        Price = 499.99M,
                        ReleaseDate = DateTime.Parse("2020-11-12"),
                        Version = 1.0M,
                        Colour = "Black"
                    },

                    new Playstations
                    {
                        ModelName = "PS4",
                        Manufacturer = "Sony",
                        StorageCapacityGB = 500,
                        Price = 299.99M,
                        ReleaseDate = DateTime.Parse("2013-11-15"),
                        Version = 2.0M,
                        Colour = "Blue"
                    },

                    new Playstations
                    {
                        ModelName = "Xbox Series X",
                        Manufacturer = "Microsoft",
                        StorageCapacityGB = 1000,
                        Price = 499.99M,
                        ReleaseDate = DateTime.Parse("2020-11-10"),
                        Version = 3.0M,
                        Colour = "White"
                    },

                    new Playstations
                    {
                        ModelName = "Nintendo Switch",
                        Manufacturer = "Nintendo",
                        StorageCapacityGB = 32,
                        Price = 299.99M,
                        ReleaseDate = DateTime.Parse("2017-03-03"),
                        Version = 4.0M,
                        Colour = "Golden"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}