namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropemailcolunm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Complaints", "Email_address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Complaints", "Email_address", c => c.String());
        }
    }
}
