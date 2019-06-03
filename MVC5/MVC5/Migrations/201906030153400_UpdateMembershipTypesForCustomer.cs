namespace MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesForCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "MembershipTypes_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTypes_Id");
            AddForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypes_Id" });
            DropColumn("dbo.Customers", "MembershipTypes_Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
