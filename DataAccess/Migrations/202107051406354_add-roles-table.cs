namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrolestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(maxLength: 1));
            AlterColumn("dbo.Roles", "Description", c => c.String(maxLength: 50));
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            AlterColumn("dbo.Roles", "Description", c => c.String());
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            DropColumn("dbo.Admins", "RoleId");
        }
    }
}
