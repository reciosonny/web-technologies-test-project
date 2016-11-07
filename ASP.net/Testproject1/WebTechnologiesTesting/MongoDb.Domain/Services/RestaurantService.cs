using MongoDb.Domain.Data.Entities;
using MongoDb.Domain.Repositories;
using MongoDb.Domain.Unit;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Services {
    public class RestaurantService {


        private RestaurantRepository restaurants = new RestaurantRepository();

        public void AddNewRestaurant() {
            var restaurant = new Restaurant() {
                //RestaurantId = "41704620",
                Name = "XYZ Restaurant",
                Borough = "Manhattan",
                Cuisine = "Italian",
                Address = new Address() {
                    Street = "2 Avenue",
                    Zipcode = "10075",
                    Building = "1480",
                    Coordinates = new Coordinates() {
                        xCoordinate = 73.9557413,
                        yCoordinate = 40.7720266
                    }
                },
                Grades = new List<Grade>() {
                    new Grade() {
                        Date = new DateTime(),
                        Score = 20,
                        GradeRating = "A"
                    }
                },
                Owners = new List<string>() {
                    "Harry",
                    "Potter"
                }
            };

            //await uo.Restaurants.AddAsync(restaurant);
            restaurants.Add(restaurant);
            
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string restaurantName) {
            return restaurants.FindRestaurantByName(restaurantName);
        }

        public IEnumerable<Restaurant> SortRestaurantListsByName() {
            return restaurants.SortRestaurantListsByName();
        }

        public Restaurant GetFirstResult() {
            return restaurants.GetItem();
        }

        public Restaurant GetById(string id) {
            return restaurants.FindItem(id);
        }

        public IEnumerable<Restaurant> SortRestaurantListsByBorough() {
            return restaurants.SortRestaurantListsByBorough();
        }

        public void Update() {
            var model = restaurants.FindItem("57822234bc3cde4674c712e2");
            model.Name = "XXX Restaurant";

            restaurants.Update(model);
        }

        public bool DeleteRestaurant(string id) {
            return restaurants.Delete(id);
        }


    }
}
