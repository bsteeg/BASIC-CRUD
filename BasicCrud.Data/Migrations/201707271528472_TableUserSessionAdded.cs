namespace BasicCrud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUserSessionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TokenCreated = c.DateTime(nullable: false),
                        Token = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSessions", "UserId", "dbo.Users");
            DropIndex("dbo.UserSessions", new[] { "UserId" });
            DropTable("dbo.UserSessions");
        }
    }
}
