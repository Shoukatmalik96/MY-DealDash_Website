namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuctionID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .Index(t => t.AuctionID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AuctionPictures", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionPictures", "PictureID", "dbo.Pictures");
            DropIndex("dbo.Auctions", new[] { "CategoryID" });
            DropIndex("dbo.AuctionPictures", new[] { "PictureID" });
            DropIndex("dbo.AuctionPictures", new[] { "AuctionID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Auctions");
            DropTable("dbo.Pictures");
            DropTable("dbo.AuctionPictures");
        }
    }
}
