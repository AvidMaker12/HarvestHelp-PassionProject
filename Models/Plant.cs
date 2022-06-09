using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HarvestHelp_PassionProject.Models
{
    public class Plant
    {
       //Primary key for Plants table
        [Key]
        //Plants table: describes plants
        public int PlantId { get; set; }

        public string PlantName { get; set; }

        public int ZoneId { get; set; }

        public string SowDate { get; set; }

        public string HarvestDate { get; set; }

        public int Sunlight { get; set; }

        public int SoilType { get; set; }

        public string FertilizerMix { get; set; }

    }
}