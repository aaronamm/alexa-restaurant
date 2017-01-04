namespace AlexaRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRestaurantNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}
