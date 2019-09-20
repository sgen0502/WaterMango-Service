using System;
using System.Composition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WaterMango_Service.Models;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Communication.InMemoryDb.Helper
{
    [Export(typeof(IInMemeoryDbGenerator<PlantModel>))]
    [Shared]
    public class PlantInMemoryDbGenerator : IInMemeoryDbGenerator<PlantModel>
    {
        
        public PlantInMemoryDbGenerator()
        {
            
        }
        
        public InMemoryDbContext<PlantModel> BuildDb()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext<PlantModel>>()
                .UseInMemoryDatabase(databaseName: "PlantDb")
                .Options;

            var context = new InMemoryDbContext<PlantModel>(options);
            context.Rows.AddRange(
                new PlantModel
                {
                    Id = 1,
                    Name = "Plant1",
                    LastUpdate = DateTime.Now,
                    LastWaterSession=DateTime.Now,
                    Status = PlantStatus.OPEN
                },
                new PlantModel
                {
                    Id = 2,
                    Name = "Plant2",
                    LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(5)),
                    LastWaterSession = DateTime.Now.Subtract(TimeSpan.FromMinutes(5)),
                    Status = PlantStatus.OPEN
                },
                new PlantModel
                {
                    Id = 3,
                    Name = "Plant3",
                    LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(10)),
                    LastWaterSession = DateTime.Now.Subtract(TimeSpan.FromMinutes(10)),
                    Status = PlantStatus.OPEN
                },
                new PlantModel
                {
                    Id = 4,
                    Name = "Plant4",
                    LastUpdate = DateTime.Now.Subtract(TimeSpan.FromMinutes(359)),
                    LastWaterSession = DateTime.Now.Subtract(TimeSpan.FromMinutes(359)),
                    Status = PlantStatus.OPEN
                },
                new PlantModel
                {
                    Id = 5,
                    Name = "Plant5",
                    LastUpdate = DateTime.Now.Subtract(TimeSpan.FromHours(6)),
                    LastWaterSession = DateTime.Now.Subtract(TimeSpan.FromHours(6)),
                    Status = PlantStatus.OPEN
                });

            context.SaveChanges();

            return context;
        }

    }
}