namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelistrole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoleViewModels", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoleViewModels", "UserRole", c => c.String(nullable: false));
        }
    }
}
