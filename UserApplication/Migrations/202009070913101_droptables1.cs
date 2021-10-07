namespace UserApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptables1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AreaOfComplaints");
            DropTable("dbo.ChannelOfComplaints");
            DropTable("dbo.FieldOfComplaints");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FieldOfComplaints",
                c => new
                    {
                        FieldOfComplaintID = c.Int(nullable: false, identity: true),
                        FieldOfComplaintNames = c.String(),
                    })
                .PrimaryKey(t => t.FieldOfComplaintID);
            
            CreateTable(
                "dbo.ChannelOfComplaints",
                c => new
                    {
                        ChannelOfComplaintID = c.Int(nullable: false, identity: true),
                        ChannelOfComplaintNames = c.String(),
                    })
                .PrimaryKey(t => t.ChannelOfComplaintID);
            
            CreateTable(
                "dbo.AreaOfComplaints",
                c => new
                    {
                        AreaOfComplaintID = c.Int(nullable: false, identity: true),
                        AreaOfComplaintNames = c.String(),
                    })
                .PrimaryKey(t => t.AreaOfComplaintID);
            
        }
    }
}
