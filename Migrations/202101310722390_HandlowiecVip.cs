namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HandlowiecVip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Handlowiecs", "HandlowiecVip", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Handlowiecs", "HandlowiecVip");
        }
    }
}
