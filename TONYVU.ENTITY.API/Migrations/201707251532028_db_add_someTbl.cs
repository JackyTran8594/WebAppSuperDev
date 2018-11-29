namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_add_someTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeedBack_Id = c.String(maxLength: 5),
                        Contents = c.String(),
                        Email = c.String(maxLength: 200),
                        FullName = c.String(maxLength: 50),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Contents = c.String(),
                        Author = c.String(maxLength: 100),
                        Summary = c.String(maxLength: 200),
                        Status = c.Int(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfProduct = c.String(maxLength: 200),
                        Supplier = c.String(maxLength: 100),
                        MadeIn = c.String(maxLength: 50),
                        Descriptions = c.String(maxLength: 500),
                        Path = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        TypeOfProduct = c.String(maxLength: 20),
                        GroupOfProduct = c.String(maxLength: 20),
                        PriceOfProduct = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 100),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(maxLength: 100),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Project_Id = c.String(maxLength: 5),
                        Project_Name = c.String(maxLength: 200),
                        Descriptions = c.String(maxLength: 500),
                        Notes = c.String(maxLength: 500),
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
            DropTable("dbo.Projects");
            DropTable("dbo.Product");
            DropTable("dbo.News");
            DropTable("dbo.FeedBack");
        }
    }
}
