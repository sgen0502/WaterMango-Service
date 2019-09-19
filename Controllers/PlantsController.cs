using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WaterMango_Service.Communication.DAO;
using WaterMango_Service.Models;

namespace WaterMango_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private ICommunicationDao<PlantModel> _dao;
        
        public PlantsController()
        {
            _dao = DependencyContainer.GetExportedValue<ICommunicationDao<PlantModel>>();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PlantModel>> Get()
        {
            return _dao.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PlantModel> Get(int id)
        {
            return _dao.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PlantModel value)
        {
            _dao.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _dao.Update(_dao.Find(id));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dao.Delete(id);
        }
    }
}
