namespace ProsumerInfoDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateToOnModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProsumerInfoes", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ProsumerInfoes", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.ProsumerInfoes", "Production_ProductionID", "dbo.Productions");
            AddForeignKey("dbo.ProsumerInfoes", "Address_AddressId", "dbo.Addresses", "AddressId");
            AddForeignKey("dbo.ProsumerInfoes", "Owner_OwnerID", "dbo.Owners", "OwnerID");
            AddForeignKey("dbo.ProsumerInfoes", "Production_ProductionID", "dbo.Productions", "ProductionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProsumerInfoes", "Production_ProductionID", "dbo.Productions");
            DropForeignKey("dbo.ProsumerInfoes", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.ProsumerInfoes", "Address_AddressId", "dbo.Addresses");
            AddForeignKey("dbo.ProsumerInfoes", "Production_ProductionID", "dbo.Productions", "ProductionID", cascadeDelete: true);
            AddForeignKey("dbo.ProsumerInfoes", "Owner_OwnerID", "dbo.Owners", "OwnerID", cascadeDelete: true);
            AddForeignKey("dbo.ProsumerInfoes", "Address_AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}
