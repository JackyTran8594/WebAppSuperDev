namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_User_tonyvu_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "User_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "User_Id", c => c.String(maxLength: 20));
        }
    }
}
