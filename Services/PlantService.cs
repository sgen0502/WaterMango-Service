using System;
using System.Collections.Generic;
using System.Composition;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;
using WaterMango_Service.Services.Grpc;
using WaterMangoService.Models.Proto;

namespace WaterMango_Service.Services
{
    [Export]
    [Shared]
    public class PlantService
    {
        private ICommunicationDao<PlantModel> _dao;
        private ILogger _log;
        private Server _server;
        private const int Port = 50000;
        
        [ImportingConstructor]
        public PlantService(ICommunicationDao<PlantModel> dao, ILoggerFactory factory)
        {
            _dao = dao;
            _log = factory.CreateLogger<PlantService>();
            
            _server = new Server
            {
                Services = { PlantStatusUpdate.BindService(new PlantStatusGrpcService(_dao, factory)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            _server.Start();   
        }

        public void StopGrpcServer()
        {
            _server.ShutdownAsync().Wait();
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
        
        public void DeletePlant(int id)
        {
            _dao.Delete(id);   
        }
    }
}