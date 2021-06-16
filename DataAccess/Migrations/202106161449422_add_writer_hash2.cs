namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writer_hash2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            DropColumn("dbo.Writers", "AdminPasswordHash");
            DropColumn("dbo.Writers", "AdminPasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Writers", "AdminPasswordHash", c => c.Binary());
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
        }
    }
}
