namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemakingMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Movies");
        }
        
        public override void Down()
        {
        }
    }
}
