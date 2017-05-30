namespace RESTapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientOffers",
                c => new
                    {
                        OfferID = c.Int(nullable: false, identity: true),
                        OfferDate = c.DateTime(nullable: false),
                        offer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_Id = c.String(nullable: false, maxLength: 128),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfferID)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        InitialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        SellStartDate = c.DateTime(nullable: false),
                        SellEndDate = c.DateTime(nullable: false),
                        ProductSubcategoryID = c.Int(),
                        Wlasciciel_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductSubcategories", t => t.ProductSubcategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.Wlasciciel_Id, cascadeDelete: false)
                .Index(t => t.ProductSubcategoryID)
                .Index(t => t.Wlasciciel_Id);
            
            CreateTable(
                "dbo.ProductProductPhotoes",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductPhotoID = c.Int(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ProductPhotoID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ProductPhotoes", t => t.ProductPhotoID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ProductPhotoID);
            
            CreateTable(
                "dbo.ProductPhotoes",
                c => new
                    {
                        ProductPhotoID = c.Int(nullable: false, identity: true),
                        ThumbNailPhoto = c.Binary(),
                        ThumbnailPhotoFileName = c.String(),
                        LargePhoto = c.Binary(),
                        LargePhotoFileName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPhotoID);
            
            CreateTable(
                "dbo.ProductSubcategories",
                c => new
                    {
                        ProductSubcategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSubcategoryID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientOffers", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Wlasciciel_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductSubcategories", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductSubcategoryID", "dbo.ProductSubcategories");
            DropForeignKey("dbo.ProductProductPhotoes", "ProductPhotoID", "dbo.ProductPhotoes");
            DropForeignKey("dbo.ProductProductPhotoes", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ClientOffers", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProductSubcategories", new[] { "ProductCategoryID" });
            DropIndex("dbo.ProductProductPhotoes", new[] { "ProductPhotoID" });
            DropIndex("dbo.ProductProductPhotoes", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Wlasciciel_Id" });
            DropIndex("dbo.Products", new[] { "ProductSubcategoryID" });
            DropIndex("dbo.ClientOffers", new[] { "Product_ProductID" });
            DropIndex("dbo.ClientOffers", new[] { "Client_Id" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.ProductSubcategories");
            DropTable("dbo.ProductPhotoes");
            DropTable("dbo.ProductProductPhotoes");
            DropTable("dbo.Products");
            DropTable("dbo.ClientOffers");
        }
    }
}
