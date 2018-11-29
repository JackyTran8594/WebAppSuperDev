namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_add_menu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(maxLength: 100),
                        MenuId = c.String(maxLength: 10),
                        Name = c.String(maxLength: 100),
                        ParentMenu = c.String(maxLength: 10),
                        Status = c.Int(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.DateTime(),  
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu");
        }
    }
}
