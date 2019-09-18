using System.Collections.Generic;
using System.Composition;
using WaterMango_Service.Models;

namespace WaterMango_Service.Communication.DAO
{
    public interface ICommunicationDao<T>{
        T Find(int key);
        List<T> FindAll();
        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Delete(T item);
        void Delete(int key);
    }
    
    [Export(typeof(ICommunicationDao<PlantModel> ))]
    public class PlantInMemoryDataBaseDao : ICommunicationDao<PlantModel> {
        public PlantModel Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public List<PlantModel> FindAll()
        {
            return new List<PlantModel>(){new PlantModel(1)};
        }

        public void Add(PlantModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Add(List<PlantModel> items)
        {
            throw new System.NotImplementedException();
        }

        public void Update(PlantModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(PlantModel item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }
    }
}
