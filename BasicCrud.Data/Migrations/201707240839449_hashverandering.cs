namespace BasicCrud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hashverandering : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Salt", c => c.String(nullable: false));
        }
    }
}
