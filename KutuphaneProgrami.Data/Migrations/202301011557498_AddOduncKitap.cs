namespace KutuphaneProgrami.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOduncKitap : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OduncKitaps", "KitapId");
            AddForeignKey("dbo.OduncKitaps", "KitapId", "dbo.Kitaps", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OduncKitaps", "KitapId", "dbo.Kitaps");
            DropIndex("dbo.OduncKitaps", new[] { "KitapId" });
        }
    }
}
