using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Data.Entities {
    public class Restaurant : Entity {

        public string Name { get; set; }
        public string Borough { get; set; }
        public string Cuisine { get; set; }
        public List<Grade> Grades { get; set; }
        public Address Address { get; set; }
        public List<string> Owners { get; set; }



    }
}
