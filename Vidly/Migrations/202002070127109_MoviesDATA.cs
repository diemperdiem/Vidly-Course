namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesDATA : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,Genere_Id,ReleaseDate, DateAdded,NumberInStock) VALUES ('Die Hard',2,'19880712','20200102',1)");
            Sql("INSERT INTO Movies (Name,Genere_Id,ReleaseDate, DateAdded,NumberInStock) VALUES ('The Terminator',2,'19841026','20200102',10)");
            Sql("INSERT INTO Movies (Name,Genere_Id,ReleaseDate, DateAdded,NumberInStock) VALUES ('Toy Story',3,'19960321','20200103',5)");
            Sql("INSERT INTO Movies (Name,Genere_Id,ReleaseDate, DateAdded,NumberInStock) VALUES ('Titanic',4,'19980101','20200104',6)");
        }
        
        public override void Down()
        {
        }
    }
}
