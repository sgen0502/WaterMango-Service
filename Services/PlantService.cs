using System;
using System.Collections.Generic;
using System.Composition;
using Microsoft.Extensions.Logging;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Services
{
    [Export]
    [Shared]
    public class PlantService
    {
        private ICommunicationDao<PlantModel> _dao;
        private ILogger _log;
        private const int Port = 50000;
        
        [ImportingConstructor]
        public PlantService(ICommunicationDao<PlantModel> dao, ILoggerFactory factory)
        {
            _log = factory.CreateLogger<PlantService>();
            _dao = dao;
        }

        public PlantModel GetPlant(int id)
        {
            return _dao.Find(id);
        }

        public List<PlantModel> GetAllPlants()
        {
            return _dao.FindAll();
        }

        public void AddPlant(PlantModel item)
        {
            _dao.Add(item);
        }
        
        public void UpdatePlant(PlantModel item)
        {
            item.LastUpdate = DateTime.Now;
            _dao.Update(item);
        }
        
        public void GiveWaterToPlant(PlantModel item)
        {
            //Defensive Code
            if (item.Status == PlantStatus.WAITING)
            {
                throw new Exception("Wait Time.");        
            }
            else if (item.Status == PlantStatus.WATERING)
            {
                //When Watering Cancel current session and go rest
                item.LastUpdate = DateTime.Now;
                item.Status = PlantStatus.WAITING;
                _dao.Update(item);
            }
            else
            {
                // Case when Alert or Open session
                // Update all timestamp and move to Waterinmg Session
                item.LastUpdate = DateTime.Now;
                item.LastWaterSession = DateTime.Now;
                item.Status = PlantStatus.WATERING;
                _dao.Update(item);
            }
        }
        
        public void DeletePlant(int id)
        {
            _dao.Delete(id);   
        }
    }
}