namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtrash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "Trash");
        }
    }
}
