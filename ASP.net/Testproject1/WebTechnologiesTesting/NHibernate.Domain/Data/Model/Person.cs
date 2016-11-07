using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Data.Model {
    public class Person {
        //public int Id { get; set; }

        public virtual Guid Id { get; set; }
        public virtual string Fname { get; set; }
        public virtual string Mname { get; set; }
        public virtual string Lname { get; set; }
        public virtual Guid PersonInformationId { get; set; }
    }
}


