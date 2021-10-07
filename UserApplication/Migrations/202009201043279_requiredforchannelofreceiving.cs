namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredforchannelofreceiving : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaints", "ChannelOfReceivingID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaints", "ChannelOfReceivingID", c => c.String());
        }
    }
}
