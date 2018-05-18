using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerInfoDB.Models
{
    public class Production
    {
        [Key]
        public int ProductionID { get; set; }
        public int AverageProduction { get; set; }
        public int AverageConsumer { get; set; }
        public int Balance { get; set; }
    }
}
