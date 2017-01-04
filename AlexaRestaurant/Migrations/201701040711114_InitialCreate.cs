namespace AlexaRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RandomedRestaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false),
                        CreatedUtcTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.RestaurantId, t.CreatedUtcTime })
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RandomedRestaurants", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RandomedRestaurants", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.RandomedRestaurants");
        }
    }
}
