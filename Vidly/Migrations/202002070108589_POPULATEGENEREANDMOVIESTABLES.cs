namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POPULATEGENEREANDMOVIESTABLES : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENERES (Id,Description) VALUES(1,'Comedy')");
            Sql("INSERT INTO GENERES (Id,Description) VALUES(2,'Action')");
            Sql("INSERT INTO GENERES (Id,Description) VALUES(2,'Family')");
            Sql("INSERT INTO GENERES (Id,Description) VALUES(4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
