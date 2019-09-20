using System;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Models
{
    public class PlantModel
    {
        public PlantModel()
        {
        }

        public PlantModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name {get; set;}
        
        public DateTime LastWaterSession {get; set;}
        public DateTime LastUpdate {get; set;}
        public PlantStatus Status {get; set;}
    }
}
