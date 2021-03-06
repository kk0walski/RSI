namespace RSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Gender = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        ProductCategory = c.Int(),
                        category_ProductCategoryID = c.Int(),
                        Wlasciciel_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.category_ProductCategoryID)
                .ForeignKey("dbo.AspNetUsers", t => t.Wlasciciel_Id, cascadeDelete: false)
                .Index(t => t.category_ProductCategoryID)
                .Index(t => t.Wlasciciel_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClientOffers", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "Wlasciciel_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductProductPhotoes", "ProductPhotoID", "dbo.ProductPhotoes");
            DropForeignKey("dbo.ProductProductPhotoes", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "category_ProductCategoryID", "dbo.Categories");
            DropForeignKey("dbo.ClientOffers", "Client_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductProductPhotoes", new[] { "ProductPhotoID" });
            DropIndex("dbo.ProductProductPhotoes", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Wlasciciel_Id" });
            DropIndex("dbo.Products", new[] { "category_ProductCategoryID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ClientOffers", new[] { "Product_ProductID" });
            DropIndex("dbo.ClientOffers", new[] { "Client_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductPhotoes");
            DropTable("dbo.ProductProductPhotoes");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ClientOffers");
        }
    }
}
