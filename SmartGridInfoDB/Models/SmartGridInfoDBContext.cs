using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartGridInfoDB.Models
{
    public class SmartGridInfoDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SmartGridInfoDBContext() : base("name=SmartGridInfoProduction")
        {
        }

        public System.Data.Entity.DbSet<SmartGridInfoDB.Models.SmartMeter> SmartMeters { get; set; }

        public System.Data.Entity.DbSet<SmartGridInfoDB.Models.WireInfo> WireInfoes { get; set; }

        public System.Data.Entity.DbSet<SmartGridInfoDB.Models.SmartGridInfo> SmartGridInfoes { get; set; }

        public System.Data.Entity.DbSet<SmartGridInfoDB.Models.StorageInfo> StorageInfoes { get; set; }

        public System.Data.Entity.DbSet<SmartGridInfoDB.Models.Adress> Adresses { get; set; }
    }
}
