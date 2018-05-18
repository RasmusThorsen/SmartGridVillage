using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class Adress
    {
        [Key]
        public int AdresseId { get; set; }

        public string Streetname { get; set; }
        public string Housenumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

    }
}