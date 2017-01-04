namespace AlexaRestaurant.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.RestaurantContext>
    {
        public Configuration()
        {
            //To manually run Add-Migration and Update-Database
            AutomaticMigrationsEnabled = false;
        }
    }
}
