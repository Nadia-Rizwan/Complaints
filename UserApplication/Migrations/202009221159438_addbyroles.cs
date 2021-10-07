namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbyroles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "NoteNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Complaints", "AddedBy", c => c.String());
            AddColumn("dbo.Complaints", "AddedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Complaints", "AddedTime");
            DropColumn("dbo.Complaints", "AddedBy");
            DropColumn("dbo.Complaints", "NoteNumber");
        }
    }
}
