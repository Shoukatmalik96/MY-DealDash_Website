namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAuctionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "StartingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "EndingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "StartingTime");
            DropColumn("dbo.Auctions", "EndingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "EndingTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "StartingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "EndingDate");
            DropColumn("dbo.Auctions", "StartingDate");
        }
    }
}
