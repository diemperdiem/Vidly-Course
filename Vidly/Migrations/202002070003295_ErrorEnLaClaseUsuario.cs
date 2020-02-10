namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorEnLaClaseUsuario : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MembershipTypue_Id", newName: "MembershipType_Id");
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypue_Id", newName: "IX_MembershipType_Id");
            DropColumn("dbo.Customers", "MemebershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemebershipTypeId", c => c.Byte(nullable: false));
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipType_Id", newName: "IX_MembershipTypue_Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypue_Id");
        }
    }
}
