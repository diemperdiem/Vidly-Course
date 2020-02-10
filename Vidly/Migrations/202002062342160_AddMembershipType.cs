namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MemebershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypue_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTypue_Id");
            AddForeignKey("dbo.Customers", "MembershipTypue_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypue_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypue_Id" });
            DropColumn("dbo.Customers", "MembershipTypue_Id");
            DropColumn("dbo.Customers", "MemebershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
