namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercomplaint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AreaOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropForeignKey("dbo.ChannelOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropForeignKey("dbo.FieldOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropIndex("dbo.AreaOfComplaints", new[] { "Complaint_ID" });
            DropIndex("dbo.ChannelOfComplaints", new[] { "Complaint_ID" });
            DropIndex("dbo.FieldOfComplaints", new[] { "Complaint_ID" });
            DropColumn("dbo.AreaOfComplaints", "Complaint_ID");
            DropColumn("dbo.ChannelOfComplaints", "Complaint_ID");
            DropColumn("dbo.FieldOfComplaints", "Complaint_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FieldOfComplaints", "Complaint_ID", c => c.String(maxLength: 128));
            AddColumn("dbo.ChannelOfComplaints", "Complaint_ID", c => c.String(maxLength: 128));
            AddColumn("dbo.AreaOfComplaints", "Complaint_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.FieldOfComplaints", "Complaint_ID");
            CreateIndex("dbo.ChannelOfComplaints", "Complaint_ID");
            CreateIndex("dbo.AreaOfComplaints", "Complaint_ID");
            AddForeignKey("dbo.FieldOfComplaints", "Complaint_ID", "dbo.Complaints", "ID");
            AddForeignKey("dbo.ChannelOfComplaints", "Complaint_ID", "dbo.Complaints", "ID");
            AddForeignKey("dbo.AreaOfComplaints", "Complaint_ID", "dbo.Complaints", "ID");
        }
    }
}
