namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delte : DbMigration
    {
        public override void Up()
        {
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
