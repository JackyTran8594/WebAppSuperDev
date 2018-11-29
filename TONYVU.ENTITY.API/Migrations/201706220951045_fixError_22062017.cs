namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixError_22062017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserStatus");
        }
    }
}
