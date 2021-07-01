namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminnameadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
