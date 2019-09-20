using System.Collections.Generic;
using System.Composition;
using System.Linq;
using WaterMango_Service.Communication.InMemoryDb;
using WaterMango_Service.Communication.InMemoryDb.Helper;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.DAO
{
    [Export(typeof(ICommunicationDao<RuleModel>))]
    [Shared]
    public class RuleInMemoryDataBaseDao : ICommunicationDao<RuleModel>
    {
        private InMemoryDbContext<RuleModel> context;
        
        [ImportingConstructor]
        public RuleInMemoryDataBaseDao(IInMemeoryDbGenerator<RuleModel> generator)
        {
            context = generator.BuildDb();
        }
        public RuleModel Find(int id)
        {
            return context.Rows
                .First(x => x.Id == id);
        }

        public List<RuleModel> FindAll()
        {
            return context.Rows.ToList();
        }

        public void Add(RuleModel item)
        {
            context.Rows.Add(item);
            context.SaveChanges();
        }

        public void Add(List<RuleModel> items)
        {
            items.ForEach(i => context.Rows.Add(i));
            context.SaveChanges();
        }

        public void Update(RuleModel item)
        {
            context.Rows.Update(item);
            context.SaveChanges();
        }
        
        public void Delete(RuleModel item)
        {
            context.Rows.Remove(item);
        }

        public void Delete(int id)
        {
            context.Remove(Find(id));
        }
    }
}