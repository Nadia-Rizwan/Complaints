namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterdropcolnm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "ChannelOfReceivingID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "ChannelOfReceivingID", c => c.Boolean(nullable: false));
        }
    }
}
