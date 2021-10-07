namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptables : DbMigration
    {
        public override void Up()
        {


            CreateTable(
               "dbo.StateNames",
               c => new
               {
                   StateId = c.Int(nullable: false, identity: true),
                   StateName = c.String(),
                   CountryId = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.StateId);

            CreateTable(
                "dbo.CountryNames",
                c => new
                {
                    CountryId = c.Int(nullable: false, identity: true),
                    CountryName = c.String(),
                })
                .PrimaryKey(t => t.CountryId);

        }
        
        public override void Down()
        {

            CreateIndex("dbo.StateNames", "CountryId");
            AddForeignKey("dbo.StateNames", "CountryId", "dbo.CountryNames", "CountryId", cascadeDelete: false);
            DropForeignKey("dbo.StateNames", "CountryId", "dbo.CountryNames");
            DropIndex("dbo.StateNames", new[] { "CountryId" });
            DropTable("dbo.CountryNames");
            DropTable("dbo.StateNames");
        }
    }
}
