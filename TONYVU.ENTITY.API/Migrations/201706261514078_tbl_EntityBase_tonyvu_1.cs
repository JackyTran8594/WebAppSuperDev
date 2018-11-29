namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_EntityBase_tonyvu_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupRole", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.GroupRole", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.GroupRole", "DeleteDate", c => c.DateTime());
            AlterColumn("dbo.Role", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Role", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.Role", "DeleteDate", c => c.DateTime());
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.User", "UpdateDate", c => c.DateTime());
            AlterColumn("dbo.User", "DeleteDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "DeleteDate", c => c.String());
            AlterColumn("dbo.User", "UpdateDate", c => c.String());
            AlterColumn("dbo.User", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Role", "DeleteDate", c => c.String());
            AlterColumn("dbo.Role", "UpdateDate", c => c.String());
            AlterColumn("dbo.Role", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GroupRole", "DeleteDate", c => c.String());
            AlterColumn("dbo.GroupRole", "UpdateDate", c => c.String());
            AlterColumn("dbo.GroupRole", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
