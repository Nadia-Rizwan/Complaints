namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbyrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "AddedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "AddedBy", c => c.String());
        }
    }
}
