namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaOfComplaints",
                c => new
                    {
                        AreaOfComplaintID = c.String(nullable: false, maxLength: 128),
                        AreaOfComplaintNames = c.String(),
                        Complaint_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AreaOfComplaintID)
                .ForeignKey("dbo.Complaints", t => t.Complaint_ID)
                .Index(t => t.Complaint_ID);
            
            CreateTable(
                "dbo.ChannelOfComplaints",
                c => new
                    {
                        ChannelOfComplaintID = c.String(nullable: false, maxLength: 128),
                        ChannelOfComplaintNames = c.String(),
                        Complaint_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ChannelOfComplaintID)
                .ForeignKey("dbo.Complaints", t => t.Complaint_ID)
                .Index(t => t.Complaint_ID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ComplaintDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Name = c.String(nullable: false),
                        EmirateID = c.String(),
                        Area = c.String(),
                        SchoolTransportService = c.Boolean(nullable: false),
                        LogisticsService = c.Boolean(nullable: false),
                        TransportationRentalService = c.Boolean(nullable: false),
                        AdministrativeNote = c.Boolean(nullable: false),
                        ExecutiveNote = c.Boolean(nullable: false),
                        TechnicalNote = c.Boolean(nullable: false),
                        Acknowledgment = c.Boolean(nullable: false),
                        Other = c.Boolean(nullable: false),
                        OthersDiscription = c.String(),
                        AreaofComplaintID = c.String(),
                        ChannelID = c.String(),
                        FieldofComplaintID = c.String(),
                        IsExisiting = c.Boolean(nullable: false),
                        Normal = c.Boolean(nullable: false),
                        Urgent = c.Boolean(nullable: false),
                        Complicated = c.Boolean(nullable: false),
                        ChannelOfReceivingID = c.String(nullable: false),
                        Subject = c.String(),
                        SubjectDescription = c.String(),
                        SuggestionsNo = c.Boolean(nullable: false),
                        SuggestionsYes = c.Boolean(nullable: false),
                        SuggestionDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FieldOfComplaints",
                c => new
                    {
                        FieldOfComplaintID = c.String(nullable: false, maxLength: 128),
                        FieldOfComplaintNames = c.String(),
                        Complaint_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FieldOfComplaintID)
                .ForeignKey("dbo.Complaints", t => t.Complaint_ID)
                .Index(t => t.Complaint_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FieldOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropForeignKey("dbo.ChannelOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropForeignKey("dbo.AreaOfComplaints", "Complaint_ID", "dbo.Complaints");
            DropIndex("dbo.FieldOfComplaints", new[] { "Complaint_ID" });
            DropIndex("dbo.ChannelOfComplaints", new[] { "Complaint_ID" });
            DropIndex("dbo.AreaOfComplaints", new[] { "Complaint_ID" });
            DropTable("dbo.FieldOfComplaints");
            DropTable("dbo.Complaints");
            DropTable("dbo.ChannelOfComplaints");
            DropTable("dbo.AreaOfComplaints");
        }
    }
}
