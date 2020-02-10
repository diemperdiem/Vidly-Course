namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeRequiredMethods : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "Genere_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Genere_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genere_Id");
            AddForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "Genere_Id" });
            AlterColumn("dbo.Movies", "Genere_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            CreateIndex("dbo.Movies", "Genere_Id");
            AddForeignKey("dbo.Movies", "Genere_Id", "dbo.Generes", "Id");
        }
    }
}
