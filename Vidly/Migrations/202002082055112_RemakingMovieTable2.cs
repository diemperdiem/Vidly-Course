namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemakingMovieTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genere_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genere_Id");
            AddForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes", "Id");
        }
        
        public override void Down()
        {
           
        }
    }
}
