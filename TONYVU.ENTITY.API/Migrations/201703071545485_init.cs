namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupRole_Id = c.String(maxLength: 5),
                        GroupRole_Name = c.String(maxLength: 200),
                        Notes = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.String(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role_Id = c.String(maxLength: 5),
                        Role_Name = c.String(maxLength: 100),
                        Notes = c.String(),
                        GroupRole_Id = c.String(maxLength: 5),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.String(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 20),
                        UserName = c.String(maxLength: 100),
                        Password_User = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
                        Address_User = c.String(),
                        Notes = c.String(),
                        Role_Id = c.String(maxLength: 5),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.String(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.GroupRole");
        }
    }
}
