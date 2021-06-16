namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writer_hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "AdminPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "AdminPasswordSalt");
            DropColumn("dbo.Writers", "AdminPasswordHash");
        }
    }
}
