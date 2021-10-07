namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaOfComplaints",
                c => new
                    {
                        AreaOfComplaintID = c.Int(nullable: false, identity: true),
                        AreaOfComplaintName = c.String(),
                    })
                .PrimaryKey(t => t.AreaOfComplaintID);
            
            CreateTable(
                "dbo.ChannelOfComplaints",
                c => new
                    {
                        ChannelOfComplaintID = c.Int(nullable: false, identity: true),
                        ChannelOfComplaintName = c.String(),
                    })
                .PrimaryKey(t => t.ChannelOfComplaintID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComplaintDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Name = c.String(),
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
                        ChannelOfReceivingID = c.String(),
                        Subject = c.String(),
                        SubjectDescription = c.String(),
                        SuggestionsNo = c.Boolean(nullable: false),
                        SuggestionsYes = c.Boolean(nullable: false),
                        SuggestionDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FieldOfComplaints",
                c => new
                    {
                        FieldOfComplaintID = c.Int(nullable: false, identity: true),
                        FieldOfComplaintName = c.String(),
                    })
                .PrimaryKey(t => t.FieldOfComplaintID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FieldOfComplaints");
            DropTable("dbo.Complaints");
            DropTable("dbo.ChannelOfComplaints");
            DropTable("dbo.AreaOfComplaints");
        }
    }
}
