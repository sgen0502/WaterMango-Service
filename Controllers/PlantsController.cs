using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;
using WaterMango_Service.Services;
using WaterMango_Service.Utils;

namespace WaterMango_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private PlantService _service;
        
        public PlantsController()
        {
            _service = DependencyContainer.GetExportedValue<PlantService>();
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<PlantModel>> Get()
        {
            return _service.GetAllPlants();
        }

        
        [HttpGet("{id}")]
        public ActionResult<PlantModel> Get(int id)
        {
            return _service.GetPlant(id);
        }

        
        [HttpPost]
        public void Post([FromBody] PlantModel value)
        {
            _service.AddPlant(value);
        }

        
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id)
        {
            try
            {
                _service.GiveWaterToPlant(_service.GetPlant(id));
            }
            catch
            {
                return Conflict("Currently Wait Time");
            }

            return Ok($"Start giving water for plant id =  {id}");
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeletePlant(id);
        }
    }
}
