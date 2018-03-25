namespace BasicCrud.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailUserAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Salt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Salt", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "Email");
        }
    }
}
