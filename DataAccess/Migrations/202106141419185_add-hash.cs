namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhash : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary(maxLength:500));
            DropColumn("dbo.Admins", "AdminMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
        }
    }
}
