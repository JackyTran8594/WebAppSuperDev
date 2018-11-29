namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_menu_ver2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "OrdinalNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "OrdinalNumber");
        }
    }
}
