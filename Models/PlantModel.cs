using System;

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
        public DateTime LastUpdate {get; set;}
        public bool IsResting {get; set;}
        public bool IsAlert {get; set;}
    }
}
