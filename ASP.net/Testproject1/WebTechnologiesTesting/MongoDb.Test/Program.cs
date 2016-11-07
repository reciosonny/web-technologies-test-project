using MongoDb.Domain.Data.Core;
using MongoDb.Domain.Data.Entities;
using MongoDb.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Test {
    class Program {
        static void Main(string[] args) {

            //var mongodb = new MongoDbHelper<Restaurant>();
            //var list = mongodb.CheckCollections();
            //var document = list[0];
            //var test = document["name"] == "Restaurant";


            var service = new RestaurantService();
            service.AddNewRestaurant();
            //mongodb.Initialize();

            //var result = mongodb.GetFirstResult();
            //var result2 = mongodb.SortRestaurantListsByBorough();
            Console.Write("done!");
        }
        
    }
}
