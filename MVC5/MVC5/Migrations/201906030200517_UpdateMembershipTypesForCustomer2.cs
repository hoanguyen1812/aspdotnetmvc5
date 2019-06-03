namespace MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypesForCustomer2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypes_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypes_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipTypes_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypes_Id");
            AddForeignKey("dbo.Customers", "MembershipTypes_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
