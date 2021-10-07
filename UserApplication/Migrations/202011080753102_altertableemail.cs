namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertableemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "Email_address", c => c.String());
           
            DropColumn("dbo.EmailDepartments", "Email_address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailDepartments", "Email_address", c => c.String());
            
            DropColumn("dbo.Complaints", "Email_address");
        }
    }
}
