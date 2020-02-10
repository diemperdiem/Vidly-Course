namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schemeupdatedformovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenereId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenereId");
        }
    }
}
