namespace DacSan3Mien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        image = c.String(nullable: false),
                        price = c.Single(nullable: false),
                        status = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "regionId", "dbo.Regions");
            DropIndex("dbo.Products", new[] { "regionId" });
            DropTable("dbo.Users");
            DropTable("dbo.Regions");
            DropTable("dbo.Products");
        }
    }
}
