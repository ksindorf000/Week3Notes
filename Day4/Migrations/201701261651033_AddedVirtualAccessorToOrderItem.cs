namespace Day4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtualAccessorToOrderItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "Product_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.OrderItems", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            CreateIndex("dbo.OrderItems", "ProductId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "ProductId", c => c.Int());
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.OrderItems", "Product_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
