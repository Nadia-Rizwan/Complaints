namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkeyvalues : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CountryNames", newName: "Countries");
            RenameTable(name: "dbo.StateNames", newName: "States");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.States", newName: "StateNames");
            RenameTable(name: "dbo.Countries", newName: "CountryNames");
        }
    }
}
