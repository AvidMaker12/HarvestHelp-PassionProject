using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HarvestHelp_PassionProject.Models
{
    public class HarvestStat
    {
        //Primary key for HarvestStats table
        [Key]
        //HarvestStats table: describes statistics for crops
        public int HarvestId { get; set; }

        //Foreign Key from Users table
        public int UserId { get; set; }

        //Foreign Key from Plants table
        public int PlantId { get; set; }

        //Plant status:
            // 1 = planted
            // 2 = harvested
            // 3 = plant expiration/failure
        public int Status { get; set; }


    }
}