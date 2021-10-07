namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemailcolumtoemaildeparment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailDepartments", "Email_Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailDepartments", "Email_Address");
        }
    }
}
