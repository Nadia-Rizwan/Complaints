namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlanguage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "PhoneNumber", c => c.String());
        }
    }
}
