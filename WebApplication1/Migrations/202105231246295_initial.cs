namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizer",
                c => new
                    {
                        OrganizerID = c.Int(nullable: false, identity: true),
                        OrganizerName = c.String(nullable: false),
                        OrganizerEmail = c.String(),
                        OrganizerMobileNo = c.String(),
                        OrganizerAddress = c.String(),
                    })
                .PrimaryKey(t => t.OrganizerID);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        SeminarID = c.Int(nullable: false),
                        ParticipantName = c.String(nullable: false),
                        ParticipantEmail = c.String(),
                        ParticipantMobileNo = c.String(),
                        ParticipantDOB = c.DateTime(),
                        IsAttended = c.Boolean(),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateTable(
                "dbo.Seminar",
                c => new
                    {
                        SeminarID = c.Int(nullable: false, identity: true),
                        OrganizerID = c.Int(nullable: false),
                        SeminarTitle = c.String(nullable: false),
                        SeminarDescription = c.String(),
                        SeminarType = c.String(nullable: false),
                        SeminarDate = c.DateTime(nullable: false),
                        SeminarStartTime = c.String(nullable: false),
                        SeminarEndTime = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SeminarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seminar");
            DropTable("dbo.Participant");
            DropTable("dbo.Organizer");
        }
    }
}
