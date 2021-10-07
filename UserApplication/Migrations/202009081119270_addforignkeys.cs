namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforignkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "ChannelOfComplaintID", c => c.Int(nullable: true));
            AlterColumn("dbo.Complaints", "AreaOfComplaintID", c => c.Int(nullable: true));
            AlterColumn("dbo.Complaints", "FieldOfComplaintID", c => c.Int(nullable: true));
            CreateIndex("dbo.Complaints", "AreaOfComplaintID");
            CreateIndex("dbo.Complaints", "ChannelOfComplaintID");
            CreateIndex("dbo.Complaints", "FieldOfComplaintID");
            AddForeignKey("dbo.Complaints", "AreaOfComplaintID", "dbo.AreaOfComplaints", "AreaOfComplaintID", cascadeDelete: true);
            AddForeignKey("dbo.Complaints", "ChannelOfComplaintID", "dbo.ChannelOfComplaints", "ChannelOfComplaintID", cascadeDelete: true);
            AddForeignKey("dbo.Complaints", "FieldOfComplaintID", "dbo.FieldOfComplaints", "FieldOfComplaintID", cascadeDelete: true);
            DropColumn("dbo.Complaints", "ChannelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Complaints", "ChannelID", c => c.String());
            DropForeignKey("dbo.Complaints", "FieldOfComplaintID", "dbo.FieldOfComplaints");
            DropForeignKey("dbo.Complaints", "ChannelOfComplaintID", "dbo.ChannelOfComplaints");
            DropForeignKey("dbo.Complaints", "AreaOfComplaintID", "dbo.AreaOfComplaints");
            DropIndex("dbo.Complaints", new[] { "FieldOfComplaintID" });
            DropIndex("dbo.Complaints", new[] { "ChannelOfComplaintID" });
            DropIndex("dbo.Complaints", new[] { "AreaOfComplaintID" });
            AlterColumn("dbo.Complaints", "FieldOfComplaintID", c => c.String());
            AlterColumn("dbo.Complaints", "AreaOfComplaintID", c => c.String());
            DropColumn("dbo.Complaints", "ChannelOfComplaintID");
        }
    }
}
