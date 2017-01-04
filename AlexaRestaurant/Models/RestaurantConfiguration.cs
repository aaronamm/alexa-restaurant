using System.Data.Entity.ModelConfiguration;

namespace AlexaRestaurant.Models
{
    public class RestaurantConfiguration :EntityTypeConfiguration<Restaurant> 
    {
        public RestaurantConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired();
        }
    }
}