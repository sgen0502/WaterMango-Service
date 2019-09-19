using System.Collections.Generic;
using System.Composition;
using System.Linq;
using WaterMango_Service.Communication.InMemoryDb;
using WaterMango_Service.Communication.InMemoryDb.Helper;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.DAO
{
    [Export(typeof(ICommunicationDao<PlantModel>))]
    public class PlantInMemoryDataBaseDao : ICommunicationDao<PlantModel>
    {
        private InMemoryDbContext<PlantModel> context;
        
        [ImportingConstructor]
        public PlantInMemoryDataBaseDao(PlantInMemoryDbGenerator generator)
        {
            context = generator.Context;
        }
        public PlantModel Find(int id)
        {
            return context.Rows
                .First(x => x.Id == id);
        }

        public List<PlantModel> FindAll()
        {
            return context.Rows.ToList();
        }

        public void Add(PlantModel item)
        {
            context.Rows.Add(item);
            context.SaveChanges();
        }

        public void Add(List<PlantModel> items)
        {
            items.ForEach(i => context.Rows.Add(i));
            context.SaveChanges();
        }

        public void Update(PlantModel item)
        {
            context.Rows.Update(item);
            context.SaveChanges();
        }
        
        public void Delete(PlantModel item)
        {
            context.Rows.Remove(item);
        }

        public void Delete(int id)
        {
            context.Remove(Find(id));
        }
    }
}