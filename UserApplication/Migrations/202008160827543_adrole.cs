namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoleViewModels", "UserRole", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoleViewModels", "UserRole");
        }
    }
}
