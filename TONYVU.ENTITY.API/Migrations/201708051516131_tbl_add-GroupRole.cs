namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_addGroupRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupRole", "ListRole", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupRole", "ListRole");
        }
    }
}
