namespace DacSan3Mien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        orderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        birthday = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        address = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 20),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        image = c.String(nullable: false),
                        price = c.Single(nullable: false),
                        status = c.String(nullable: false),
                        quantity = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        regionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Regions", t => t.regionId, cascadeDelete: true)
                .Index(t => t.regionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "regionId", "dbo.Regions");
            DropForeignKey("dbo.OrderDetails", "productId", "dbo.Products");
            DropForeignKey("dbo.Orders", "userId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "regionId" });
            DropIndex("dbo.Orders", new[] { "userId" });
            DropIndex("dbo.OrderDetails", new[] { "productId" });
            DropIndex("dbo.OrderDetails", new[] { "orderId" });
            DropTable("dbo.Regions");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
