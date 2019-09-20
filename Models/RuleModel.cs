using System;
using System.Collections.Generic;
using WaterMango_Service.Models.Enum;

namespace WaterMango_Service.Models
{
    public class RuleModel
    {
        public int Id { get; set; }
        
        public PlantStatus CurrentStatus { get; set; }
        public PlantStatus NextStatus { get; set; }
        public  TimeSpan Time { get; set; }
        
        public TimeTarget TimeCalcTarget { get; set; }
    }
}