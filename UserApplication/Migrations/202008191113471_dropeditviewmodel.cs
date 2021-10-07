namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropeditviewmodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EditUserViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RoleId = c.String(nullable: false),
                        CNIC = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
    }
}
