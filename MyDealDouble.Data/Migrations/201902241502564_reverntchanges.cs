namespace MyDealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverntchanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
        }
    }
}
