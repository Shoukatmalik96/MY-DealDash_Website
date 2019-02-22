namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateauctionEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "StartingTime", c => c.DateTime());
            AddColumn("dbo.Auctions", "EndingTime", c => c.DateTime());
            DropColumn("dbo.Auctions", "StartingDate");
            DropColumn("dbo.Auctions", "EndingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "EndingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "StartingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Auctions", "EndingTime");
            DropColumn("dbo.Auctions", "StartingTime");
        }
    }
}
