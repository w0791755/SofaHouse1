using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SofaHouse.Data;
using System;
using System.Linq;

namespace SofaHouse.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SofaHouseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SofaHouseContext>>()))
            {
                // Look for any movies.
                if (context.Sofa.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sofa.AddRange(
                    new Sofa
                    {
                        type = "Soft",
                        material = "cotton",
                        size = "large",
                        theme = "latest",
                        availability = "online",
                        price = "684",
                        ReleaseDate = DateTime.Parse("2021-2-12"),
                        Rating=5

                    },

                     new Sofa
                     {
                         type = "Hard",
                         material = "latex",
                         size = "small",
                         theme = "old",
                         availability = "online",
                         price = "431",
                         ReleaseDate = DateTime.Parse("2021-3-3"),
                         Rating = 6
                     },

                     new Sofa
                     {
                         type = "firm",
                         material = "cotton",
                         size = "medium",
                         theme = "latest",
                         availability = "offline",
                         price = "761",
                         ReleaseDate = DateTime.Parse("2021-4-10"),
                         Rating = 10
                     },

                    new Sofa
                    {
                        type = "Spring",
                        material = "cotton",
                        size = "small",
                        theme = "old",
                        availability = "online",
                        price = "1099",
                        ReleaseDate = DateTime.Parse("2021-6-4"),
                        Rating = 2
                    },
                     new Sofa
                     {
                         type = "Spring",
                         material = "cotton",
                         size = "large",
                         theme = "latest",
                         availability = "online",
                         price = "1899",
                         ReleaseDate = DateTime.Parse("2021-2-7"),
                         Rating = 7
                     }

                );
                context.SaveChanges();
            }
        }
    }
}
