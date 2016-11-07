using MongoDb.Domain.Data.Core;
using MongoDb.Domain.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T: Entity, new() {
        protected IMongoCollection<T> _mongoCollection;
        private List<T> AddCollection = new List<T>();

        //public GenericRepository(IMongoCollection<T> mongoCollection) { //IMongoCollection<T> mongoCollection
        //    _mongoCollection = mongoCollection; //new MongoDbHelper<T>().InstantiateCollection();
        //}

        public GenericRepository() {
            _mongoCollection = new MongoDbHelper<T>().InstantiateCollection();
        }

        public void Add(T model) {
            _mongoCollection.InsertOne(model);
        }

        public bool Update(T model) {
            var filter = Builders<T>.Filter.Where(x => x._id == model._id);
            //var set = Builders<T>.Update.
            //_mongoCollection.UpdateOne(filter, model.ToBsonDocument());
            var result = _mongoCollection.ReplaceOne(filter, model);
            return result.IsAcknowledged;

            //_mongoCollection.FindOneAndUpdate(model.ToBsonDocument(), model.ToBsonDocument());
        }

        public async Task AddAsync(T model) {
            await _mongoCollection.InsertOneAsync(model);
        }

        public T GetItem() {
            return _mongoCollection.Find(_ => true).First(); //returns all collections and gets first item
        }

        public T FindItem(string id) {
            //var filter = Builders<T>.Filter.Eq("_id", id);
            var filter = Builders<T>.Filter.Where(x => x._id == ObjectId.Parse(id));
            var result = _mongoCollection.Find(filter).FirstOrDefault();
            return result;
        }

        public bool Delete(string id) {
            var filter = Builders<T>.Filter.Where(x => x._id == ObjectId.Parse(id));
            var result = _mongoCollection.DeleteOne(filter);

            return result.DeletedCount > 0;

            //throw new NotImplementedException();
        }
    }
}
