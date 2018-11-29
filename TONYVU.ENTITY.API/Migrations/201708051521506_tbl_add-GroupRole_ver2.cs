namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_addGroupRole_ver2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupRole", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupRole", "Status");
        }
    }
}
