using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HarvestHelp_PassionProject.Models
{
    public class Zone
    {
        //Primary key for GrowZones table
        [Key]
        //GrowZones table: describes zones
        public int ZoneId { get; set; }

        public string Zones { get; set; }



    }
}