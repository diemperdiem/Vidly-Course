namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNumberAvailable1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies set NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
