namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cahngestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "NoteNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "NoteNumber", c => c.Int(nullable: false));
        }
    }
}
