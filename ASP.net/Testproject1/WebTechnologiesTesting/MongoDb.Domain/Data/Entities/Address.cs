using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Data.Entities {
    public class Address {
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string Building { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
