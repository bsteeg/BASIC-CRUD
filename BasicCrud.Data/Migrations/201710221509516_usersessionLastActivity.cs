namespace BasicCrud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersessionLastActivity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSessions", "LastActivity", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSessions", "LastActivity");
        }
    }
}
