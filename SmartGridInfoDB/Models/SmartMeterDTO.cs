using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class SmartMeterDTO
    {
        public string Manufacturer { get; set; }
        public string SerialId { get; set; }
        public string Streetname { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        //public SmartMeter meter { get; set; }
        //public Adress adress { get; set; }
    }
}