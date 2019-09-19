using System.Composition;
using Microsoft.EntityFrameworkCore;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.InMemoryDb
{
    public class InMemoryDbContext<T> : DbContext where T : class
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext<T>> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<T> Rows { get; set; }
    }
    
    
}