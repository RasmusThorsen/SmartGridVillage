using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class StorageInfo
    {
        [Key]
        public int StorageId { get; set; }
        public int Capacity { get; set; }
    }
}