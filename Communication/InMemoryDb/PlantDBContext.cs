using System.Composition;
using Microsoft.EntityFrameworkCore;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.InMemoryDb
{
    public class PlantDbContext : DbContext
    {
        public PlantDbContext(DbContextOptions<PlantDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<PlantModel> Plants { get; }
    }
    
    
}