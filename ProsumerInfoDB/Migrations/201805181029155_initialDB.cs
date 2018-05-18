namespace ProsumerInfoDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.EnergySources",
                c => new
                    {
                        EnergySourceID = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        Production_ProductionID = c.Int(),
                    })
                .PrimaryKey(t => t.EnergySourceID)
                .ForeignKey("dbo.Productions", t => t.Production_ProductionID)
                .Index(t => t.Production_ProductionID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        ProductionID = c.Int(nullable: false, identity: true),
                        AverageProduction = c.Int(nullable: false),
                        AverageConsumer = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductionID);
            
            CreateTable(
                "dbo.ProsumerInfoes",
                c => new
                    {
                        ProsumerID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Address_AddressId = c.Int(),
                        Owner_OwnerID = c.Int(),
                        Production_ProductionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProsumerID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerID)
                .ForeignKey("dbo.Productions", t => t.Production_ProductionID)
                .Index(t => t.Address_AddressId)
                .Index(t => t.Owner_OwnerID)
                .Index(t => t.Production_ProductionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProsumerInfoes", "Production_ProductionID", "dbo.Productions");
            DropForeignKey("dbo.ProsumerInfoes", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.ProsumerInfoes", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.EnergySources", "Production_ProductionID", "dbo.Productions");
            DropIndex("dbo.ProsumerInfoes", new[] { "Production_ProductionID" });
            DropIndex("dbo.ProsumerInfoes", new[] { "Owner_OwnerID" });
            DropIndex("dbo.ProsumerInfoes", new[] { "Address_AddressId" });
            DropIndex("dbo.EnergySources", new[] { "Production_ProductionID" });
            DropTable("dbo.ProsumerInfoes");
            DropTable("dbo.Productions");
            DropTable("dbo.Owners");
            DropTable("dbo.EnergySources");
            DropTable("dbo.Addresses");
        }
    }
}
