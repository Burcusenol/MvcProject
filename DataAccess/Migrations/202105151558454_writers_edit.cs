namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writers_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }

        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 20));
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
