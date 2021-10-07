namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppingagainandagain : DbMigration
    {
        public override void Up()
        {

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

            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);








        }
        
        public override void Down()
        {


            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropTable("dbo.Countries");
            DropTable("dbo.States");

        }
    }
}
