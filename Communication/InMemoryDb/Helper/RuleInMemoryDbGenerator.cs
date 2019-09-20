using System;
using System.Composition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WaterMango_Service.Models;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Communication.InMemoryDb.Helper
{
    [Export(typeof(IInMemeoryDbGenerator<RuleModel>))]
    [Shared]
    public class RuleInMemoryDbGenerator : IInMemeoryDbGenerator<RuleModel>
    {
        
        public RuleInMemoryDbGenerator()
        {
            
        }
        
        public InMemoryDbContext<RuleModel> BuildDb()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext<RuleModel>>()
                .UseInMemoryDatabase(databaseName: "RuleDb")
                .Options;

            var context = new InMemoryDbContext<RuleModel>(options);
            context.Rows.AddRange(
                new RuleModel
                {
                    Id = 1,
                    Time = TimeSpan.FromSeconds(10),
                    CurrentStatus = PlantStatus.WATERING,
                    NextStatus = PlantStatus.WAITING,
                    TimeCalcTarget = TimeTarget.LASTUPDATE
                },
                new RuleModel
                {
                    Id = 2,
                    Time = TimeSpan.FromSeconds(30),
                    CurrentStatus = PlantStatus.WAITING,
                    NextStatus = PlantStatus.OPEN,
                    TimeCalcTarget = TimeTarget.LASTUPDATE
                },
                new RuleModel
                {
                    Id = 3,
                    Time = TimeSpan.FromHours(6),
                    CurrentStatus = PlantStatus.OPEN,
                    NextStatus = PlantStatus.ALERT,
                    TimeCalcTarget = TimeTarget.WATERSESSION
                }
            );

            context.SaveChanges();

            return context;
        }

    }
}