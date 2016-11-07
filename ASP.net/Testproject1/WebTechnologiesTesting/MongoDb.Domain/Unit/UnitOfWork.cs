using MongoDb.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Unit {
    /// <summary>
    /// note: unit of work is not necessary in MongoDb
    /// </summary>
    public class UnitOfWork {
        
        public UnitOfWork() {

        }

        public RestaurantRepository Restaurants
        {
            get
            {
                return new RestaurantRepository();
            }
        }
    }
}
