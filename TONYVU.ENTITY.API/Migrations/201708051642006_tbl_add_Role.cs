namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_add_Role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Role", "Status");
        }
    }
}
