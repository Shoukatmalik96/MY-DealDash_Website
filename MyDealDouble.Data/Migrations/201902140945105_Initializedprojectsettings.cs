namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initializedprojectsettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        pictureURL = c.String(),
                        Description = c.String(),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingTime = c.DateTime(nullable: false),
                        EndingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Auctions");
        }
    }
}
