using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Repositories {
    public interface IGenericRepository<T> where T: class {
        Task AddAsync(T model);
        void Add(T model);
        bool Update(T model);
        bool Delete(string id);
        T GetItem();
        T FindItem(string id);
    }
}
