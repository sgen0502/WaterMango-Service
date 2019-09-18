using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.InMemoryDb.Helper
{
    public class PlantDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PlantDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<PlantDbContext>>()))
        {
                // Look for any board games.
                if (context.Plants.Any())
                {
                    return; 
                }

                context.Plants.AddRange(
                    new PlantModel
                    {
                        Id = 1,
                        Name = "Plant1",
                        LastUpdate = DateTime.Now,
                        IsResting = false,
                        IsAlert = false
                    },
                    new PlantModel
                    {
                        Id = 2,
                        Name = "Plant2",
                        LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(5)),
                        IsResting = false,
                        IsAlert = false
                    },
                    new PlantModel
                    {
                        Id = 3,
                        Name = "Plant3",
                        LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(10)),
                        IsResting = false,
                        IsAlert = false
                    },
                    new PlantModel
                    {
                        Id = 4,
                        Name = "Plant4",
                        LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(30)),
                        IsResting = false,
                        IsAlert = false
                    },
                    new PlantModel
                    {
                        Id = 5,
                        Name = "Plant5",
                        LastUpdate = DateTime.Now.Subtract(TimeSpan.FromHours(6)),
                        IsResting = false,
                        IsAlert = false
                    });

                context.SaveChanges();
        }
    }
    }
}