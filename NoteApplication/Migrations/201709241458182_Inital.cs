namespace NoteApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
        }
    }
}
