namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppingtables : DbMigration
    {
        public override void Up()
        {

            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: false);
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropTable("dbo.Countries");
            DropTable("dbo.States");
        }
        
        public override void Down()
        {

         
        }
    }
}
