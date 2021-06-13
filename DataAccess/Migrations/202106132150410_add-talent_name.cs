namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtalent_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "TalentName", c => c.String());
            DropColumn("dbo.Talents", "Talents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talents", "Talents", c => c.String());
            DropColumn("dbo.Talents", "TalentName");
        }
    }
}
