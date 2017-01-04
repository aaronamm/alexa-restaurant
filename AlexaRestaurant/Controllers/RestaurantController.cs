using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlexaRestaurant.Models;


namespace AlexaRestaurant.Controllers
{
    public class RestaurantController : ApiController
    {
        private static Random random = new Random();
        const int lastRandomAmountToSkip = 3;

        [HttpPost, HttpGet, Route("hello")]
        public dynamic Hello()
        {

            using (var db = new RestaurantContext())
            {
                var lastRestaurantIdsToBeRemoveFromRandomList = db.RandomedRestaurants.OrderByDescending(r => r.CreatedUtcTime)
                    .Take(lastRandomAmountToSkip).Select(r => r.Restaurant.Id).ToList();

                var restaurants = db.Restaurants.Where(r => !lastRestaurantIdsToBeRemoveFromRandomList.Contains(r.Id)).ToList();

                var randomIndex = random.Next(0, restaurants.Count);
                var randomedRestaurant = new RandomedRestaurant()
                {
                    Restaurant = restaurants[randomIndex],
                    CreatedUtcTime = DateTime.UtcNow
                };
                db.RandomedRestaurants.Add(randomedRestaurant);
                db.SaveChanges();


                return new
                {
                    version = "1.0",
                    sessionAttributes = new { },
                    response = new
                    {
                        outputSpeech = new
                        {
                            type = "PlainText",
                            text = $"I suggest {randomedRestaurant.Restaurant.Name}"
                        },
                        card = new //not clear yet
                        {
                            type = "Simple",
                            title = "codesanook",
                            content = "Hello\nnew world"
                        },
                        shouldEndSession = true
                    }
                };
            }
        }
    }

    public class RestaurantComparer : IEqualityComparer<Restaurant>
    {
        public bool Equals(Restaurant x, Restaurant y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Restaurant obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
