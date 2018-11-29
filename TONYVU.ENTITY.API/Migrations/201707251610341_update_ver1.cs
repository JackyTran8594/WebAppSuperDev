namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_ver1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Projects", newName: "Project");
            CreateTable(
                "dbo.TypeProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(maxLength: 100),
                        TypeCode = c.String(maxLength: 10),
                        Descriptions = c.String(maxLength: 500),
                        Status = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FeedBack", "FeedBackId", c => c.String(maxLength: 5));
            AddColumn("dbo.Project", "ProjectId", c => c.String(maxLength: 5));
            AddColumn("dbo.Project", "ProjectName", c => c.String(maxLength: 200));
            DropColumn("dbo.FeedBack", "FeedBack_Id");
            DropColumn("dbo.Project", "Project_Id");
            DropColumn("dbo.Project", "Project_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "Project_Name", c => c.String(maxLength: 200));
            AddColumn("dbo.Project", "Project_Id", c => c.String(maxLength: 5));
            AddColumn("dbo.FeedBack", "FeedBack_Id", c => c.String(maxLength: 5));
            DropColumn("dbo.Project", "ProjectName");
            DropColumn("dbo.Project", "ProjectId");
            DropColumn("dbo.FeedBack", "FeedBackId");
            DropTable("dbo.TypeProduct");
            RenameTable(name: "dbo.Project", newName: "Projects");
        }
    }
}
