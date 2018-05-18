using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class WireInfo
    {
        [Key]
        public int WireId { get; set; }

        public string Manufacturer { get; set; }
        public int Length { get; set; }
        public int Thickness { get; set; }
    }
}