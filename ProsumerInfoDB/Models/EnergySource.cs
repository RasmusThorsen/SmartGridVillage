using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerInfoDB.Models
{
    public class EnergySource
    {
        [Key]
        public int EnergyID { get; set; }

        public string Source { get; set; }
    }
}
