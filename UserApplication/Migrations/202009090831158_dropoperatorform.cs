namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropoperatorform : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OperatorForms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OperatorForms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        First_name = c.String(),
                        Last_name = c.String(),
                        Father_name = c.String(),
                        cnic_no = c.String(),
                        city_name = c.String(),
                        Mobile_number = c.String(),
                        Email_Address = c.String(nullable: false),
                        Password_string = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
        }
    }
}
