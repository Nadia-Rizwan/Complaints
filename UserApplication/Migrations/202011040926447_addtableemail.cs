namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableemail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            CreateTable(
                "dbo.EmailDepartments",
                c => new
                    {
                        DId = c.Int(nullable: false, identity: true),
                        Department_Names = c.String(),
                        Email_address = c.String(),
                    })
                .PrimaryKey(t => t.DId);
            
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Languages");
           
        }
        
        public override void Down()
        {
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Progarmming_Language = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            DropTable("dbo.EmailDepartments");
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
