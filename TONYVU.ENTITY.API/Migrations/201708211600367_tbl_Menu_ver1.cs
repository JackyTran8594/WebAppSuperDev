namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_Menu_ver1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "IsHome", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "IsHome");
        }
    }
}
