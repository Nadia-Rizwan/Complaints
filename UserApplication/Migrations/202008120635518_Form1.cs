namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Form1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperatorForms", "StudentGender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperatorForms", "StudentGender");
        }
    }
}
