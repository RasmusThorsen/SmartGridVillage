using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class SmartGridInfo
    {
        [Key]
        public int SmartGridId { get; set; }

        public int NumberOfHouses { get; set; }
        public int NumberOfFirms { get; set; }

    }
}