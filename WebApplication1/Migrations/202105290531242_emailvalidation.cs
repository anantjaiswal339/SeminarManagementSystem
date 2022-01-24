namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participant", "ParticipantEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participant", "ParticipantEmail", c => c.String());
        }
    }
}
