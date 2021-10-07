namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolunmgenderoperator : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OperatorForms", "StudentGender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OperatorForms", "StudentGender", c => c.Int(nullable: false));
        }
    }
}
