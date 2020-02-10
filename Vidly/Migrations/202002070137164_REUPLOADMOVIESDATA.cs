namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REUPLOADMOVIESDATA : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Name = 'Hangover'");
        }
        
        public override void Down()
        {
        }
    }
}
