namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRequire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "AddedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "AddedBy", c => c.String(nullable: false));
        }
    }
}
