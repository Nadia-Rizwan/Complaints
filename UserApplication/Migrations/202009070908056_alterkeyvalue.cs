namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterkeyvalue : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AreaOfComplaints");
            DropPrimaryKey("dbo.ChannelOfComplaints");
            DropPrimaryKey("dbo.Complaints");
            DropPrimaryKey("dbo.FieldOfComplaints");
            AlterColumn("dbo.AreaOfComplaints", "AreaOfComplaintID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ChannelOfComplaints", "ChannelOfComplaintID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Complaints", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FieldOfComplaints", "FieldOfComplaintID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AreaOfComplaints", "AreaOfComplaintID");
            AddPrimaryKey("dbo.ChannelOfComplaints", "ChannelOfComplaintID");
            AddPrimaryKey("dbo.Complaints", "ID");
            AddPrimaryKey("dbo.FieldOfComplaints", "FieldOfComplaintID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FieldOfComplaints");
            DropPrimaryKey("dbo.Complaints");
            DropPrimaryKey("dbo.ChannelOfComplaints");
            DropPrimaryKey("dbo.AreaOfComplaints");
            AlterColumn("dbo.FieldOfComplaints", "FieldOfComplaintID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Complaints", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ChannelOfComplaints", "ChannelOfComplaintID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AreaOfComplaints", "AreaOfComplaintID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.FieldOfComplaints", "FieldOfComplaintID");
            AddPrimaryKey("dbo.Complaints", "ID");
            AddPrimaryKey("dbo.ChannelOfComplaints", "ChannelOfComplaintID");
            AddPrimaryKey("dbo.AreaOfComplaints", "AreaOfComplaintID");
        }
    }
}
