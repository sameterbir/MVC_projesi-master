namespace KutuphaneProgrami.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUye : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyes", "Mail", c => c.String(maxLength: 50));
            AddColumn("dbo.Uyes", "Sifre", c => c.String(maxLength: 32, fixedLength: true, unicode: false));
            AddColumn("dbo.Uyes", "Yetki", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uyes", "Yetki");
            DropColumn("dbo.Uyes", "Sifre");
            DropColumn("dbo.Uyes", "Mail");
        }
    }
}
