using MongoDb.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace MongoDb.Domain.Repositories {
    public class RestaurantRepository : GenericRepository<Restaurant> {
        
        //public RestaurantRepository(IMongoCollection<Restaurant> mongoCollection) : base(mongoCollection) {
        //}

        public RestaurantRepository() {

        }

        public IEnumerable<Restaurant> SortRestaurantListsByBorough() {
            //var filter = Query<Restaurant>.EQ(c => c._id, id); //Query.And(Query<Restaurant>.EQ(c => c._id, id), Query<Restaurant>.EQ(c => c.DailyPrograming.Name, "2212015"));

            //var filter = Builders<Restaurant>.Filter.Where(x => x._id == id);
            var sort = Builders<Restaurant>.Sort.Ascending(x => x.Borough);
            var result = _mongoCollection.Find(new BsonDocument()).Sort(sort).ToList();

            return result.AsEnumerable();
        }

        public IEnumerable<Restaurant> SortRestaurantListsByName() {
            var sort = Builders<Restaurant>.Sort.Ascending(x => x.Name);
            var result = _mongoCollection.Find(new BsonDocument()).Sort(sort).ToList();

            return result.AsEnumerable();

        }

        public IEnumerable<Restaurant> FindRestaurantByName(string restaurantName) {
            var filter = Builders<Restaurant>.Filter.Where(x => x.Name == restaurantName);
            var sort = Builders<Restaurant>.Sort.Ascending(x => x._id);
            var result = _mongoCollection.Find(filter).Sort(sort).ToList();

            return result.AsEnumerable();

        }
    }
}
