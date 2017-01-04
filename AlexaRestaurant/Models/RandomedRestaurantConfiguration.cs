using System.Data.Entity.ModelConfiguration;
using System;

namespace AlexaRestaurant.Models
{
    public class RandomedRestaurantConfiguration : EntityTypeConfiguration<RandomedRestaurant>
    {
        public RandomedRestaurantConfiguration()
        {
            HasKey(x => new { x.RestaurantId, x.CreatedUtcTime });
            HasRequired(x => x.Restaurant).WithMany().HasForeignKey(x=>x.RestaurantId);
            Property(x => x.CreatedUtcTime).IsRequired();
        }

    }
}