namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequiredkey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "Name", c => c.String());
        }
    }
}
