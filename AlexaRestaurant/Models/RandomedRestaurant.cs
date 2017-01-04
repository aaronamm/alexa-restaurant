using System;

namespace AlexaRestaurant.Models
{
    public class RandomedRestaurant
    {
        public virtual Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public DateTime CreatedUtcTime { get; set; }
    }
}