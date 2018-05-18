namespace SmartGridInfoDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SmartGridInfoes",
                c => new
                    {
                        SmartGridId = c.Int(nullable: false, identity: true),
                        NumberOfHouses = c.Int(nullable: false),
                        NumberOfFirms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SmartGridId);
            
            CreateTable(
                "dbo.SmartMeters",
                c => new
                    {
                        SmartMeterId = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        SerialId = c.String(),
                        Adress_AdresseId = c.Int(),
                    })
                .PrimaryKey(t => t.SmartMeterId)
                .ForeignKey("dbo.Adresses", t => t.Adress_AdresseId)
                .Index(t => t.Adress_AdresseId);
            
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseId = c.Int(nullable: false, identity: true),
                        Streetname = c.String(),
                        Housenumber = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AdresseId);
            
            CreateTable(
                "dbo.StorageInfoes",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId);
            
            CreateTable(
                "dbo.WireInfoes",
                c => new
                    {
                        WireId = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Length = c.Int(nullable: false),
                        Thickness = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WireId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SmartMeters", "Adress_AdresseId", "dbo.Adresses");
            DropIndex("dbo.SmartMeters", new[] { "Adress_AdresseId" });
            DropTable("dbo.WireInfoes");
            DropTable("dbo.StorageInfoes");
            DropTable("dbo.Adresses");
            DropTable("dbo.SmartMeters");
            DropTable("dbo.SmartGridInfoes");
        }
    }
}
