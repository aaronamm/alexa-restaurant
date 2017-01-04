using System.Data.Entity;
using System.Web.Hosting;

namespace AlexaRestaurant.Models
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RandomedRestaurant> RandomedRestaurants { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RandomedRestaurantConfiguration());
            modelBuilder.Configurations.Add(new RestaurantConfiguration());
        }
    }
}