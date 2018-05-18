using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class SmartMeter
    {
        [Key]
        public int SmartMeterId { get; set; }
        public string Manufacturer { get; set; }
        public string SerialId { get; set; }
        public virtual Adress Adress { get; set; }
    }
}