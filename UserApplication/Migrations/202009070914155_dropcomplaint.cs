namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcomplaint : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Complaints");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
            
        }
    }
}
