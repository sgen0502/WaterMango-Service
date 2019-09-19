using System.Collections.Generic;
using System.Composition;
using System.Linq;
using WaterMango_Service.Communication.InMemoryDb;
using WaterMango_Service.Communication.InMemoryDb.Helper;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.DAO
{
    public interface ICommunicationDao<T>{
        T Find(int id);
        List<T> FindAll();
        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
    }
    
    
}
