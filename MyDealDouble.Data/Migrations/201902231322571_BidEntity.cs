namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuctionID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        BidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.AuctionID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bids", "AuctionID", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "UserID" });
            DropIndex("dbo.Bids", new[] { "AuctionID" });
            DropTable("dbo.Bids");
        }
    }
}
