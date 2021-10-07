namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droplastcoulmns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Complaints", "Subject");
            DropColumn("dbo.Complaints", "SubjectDescription");
            DropColumn("dbo.Complaints", "SuggestionsNo");
            DropColumn("dbo.Complaints", "SuggestionsYes");
            DropColumn("dbo.Complaints", "SuggestionDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Complaints", "SuggestionDescription", c => c.String());
            AddColumn("dbo.Complaints", "SuggestionsYes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Complaints", "SuggestionsNo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Complaints", "SubjectDescription", c => c.String());
            AddColumn("dbo.Complaints", "Subject", c => c.String());
        }
    }
}
