using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerInfoDB.Models
{
    public class ProsumerInfo
    {
        [Key]
        public int ProsumerID { get; set; }
        public string Type { get; set; }
        public virtual Address Address { get; set; }
        public virtual Production Production { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
