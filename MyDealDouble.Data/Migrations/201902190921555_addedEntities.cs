namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEntities : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Auctions", "pictureURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "pictureURL", c => c.String());
        }
    }
}
