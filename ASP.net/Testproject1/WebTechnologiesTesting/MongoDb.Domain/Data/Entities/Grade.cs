using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Domain.Data.Entities {
    public class Grade {
        public DateTime Date { get; set; }
        public string GradeRating { get; set; }
        public int Score { get; set; }
    }
}
