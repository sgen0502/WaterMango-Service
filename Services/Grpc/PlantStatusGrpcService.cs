using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;
using WaterMangoService.Models.Proto;

namespace WaterMango_Service.Services.Grpc
{
    public class PlantStatusGrpcService : PlantStatusUpdate.PlantStatusUpdateBase
    {
        public override Task SendStatus(PlantStatus request, IServerStreamWriter<PlantStatus> responseStream, ServerCallContext context)
        {
            return base.SendStatus(request, responseStream, context);
        }
        
        private readonly ICommunicationDao<PlantModel>  _dao;
        private readonly ILogger _logger;
        
        public PlantStatusGrpcService(ICommunicationDao<PlantModel> dao, ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<PlantStatusGrpcService>();
            _dao = dao;

        }
        
    }
}