using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Data.Core {
    public class MongoDbHelper<TEntity> where TEntity: class {

        protected static IMongoClient _client;
        public static IMongoDatabase _database;

        public MongoDbHelper() {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("test");
        }

        public IMongoCollection<TEntity> InstantiateCollection() {
            Type type = typeof(TEntity);
            return _database.GetCollection<TEntity>(type.Name);
        }

        public List<BsonDocument> CheckCollections() {
            Type type = typeof(TEntity);
            var filter = new BsonDocument("name", type.Name);
            //filter by collection name
            //_database.ListCollections(new ListCollectionsOptions() { Filter = filter }).Any();
            return _database.ListCollections().ToList();
        }

        /// <summary>
        /// For sample initialization run. Comment-out this code if this is not appropriate
        /// </summary>
        //public void Initialize() {
        //    var document = new BsonDocument{
        //        { "address" , new BsonDocument
        //            {
        //                { "street", "2 Avenue" },
        //                { "zipcode", "10075" },
        //                { "building", "1480" },
        //                { "coord", new BsonArray { 73.9557413, 40.7720266 } }
        //            }
        //        },
        //        { "borough", "Manhattan" },
        //        { "cuisine", "Italian" },
        //        { "grades", new BsonArray
        //            {
        //                new BsonDocument
        //                {
        //                    { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
        //                    { "grade", "A" },
        //                    { "score", 11 }
        //                },
        //                new BsonDocument
        //                {
        //                    { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
        //                    { "grade", "B" },
        //                    { "score", 17 }
        //                }
        //            }
        //        },
        //        { "name", "Vella" },
        //        { "restaurant_id", "41704620" }
        //    };

        //    var collection = _database.GetCollection<BsonDocument>("restaurants");
        //    collection.InsertOne(document);
        //}




    }
}
