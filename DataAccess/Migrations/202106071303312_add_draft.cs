namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_draft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "isDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "isDraft");
        }
    }
}
