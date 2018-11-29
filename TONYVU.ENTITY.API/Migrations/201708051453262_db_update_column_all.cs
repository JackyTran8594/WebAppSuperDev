namespace TONYVU.ENTITY.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_update_column_all : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupRole", "GroupRoleId", c => c.String(maxLength: 5));
            AddColumn("dbo.GroupRole", "GroupRoleName", c => c.String(maxLength: 200));
            AddColumn("dbo.Role", "RoleId", c => c.String(maxLength: 5));
            AddColumn("dbo.Role", "RoleName", c => c.String(maxLength: 100));
            AddColumn("dbo.Role", "GroupRoleId", c => c.String(maxLength: 5));
            DropColumn("dbo.GroupRole", "GroupRole_Id");
            DropColumn("dbo.GroupRole", "GroupRole_Name");
            DropColumn("dbo.Role", "Role_Id");
            DropColumn("dbo.Role", "Role_Name");
            DropColumn("dbo.Role", "GroupRole_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "GroupRole_Id", c => c.String(maxLength: 5));
            AddColumn("dbo.Role", "Role_Name", c => c.String(maxLength: 100));
            AddColumn("dbo.Role", "Role_Id", c => c.String(maxLength: 5));
            AddColumn("dbo.GroupRole", "GroupRole_Name", c => c.String(maxLength: 200));
            AddColumn("dbo.GroupRole", "GroupRole_Id", c => c.String(maxLength: 5));
            DropColumn("dbo.Role", "GroupRoleId");
            DropColumn("dbo.Role", "RoleName");
            DropColumn("dbo.Role", "RoleId");
            DropColumn("dbo.GroupRole", "GroupRoleName");
            DropColumn("dbo.GroupRole", "GroupRoleId");
        }
    }
}
