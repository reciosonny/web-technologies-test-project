using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Data.Model {
    public class PersonInformation {
        public virtual Guid PersonInformationId { get; set; }
        public virtual string HomeAddress { get; set; }
        public virtual string WorkAddress { get; set; }
        public virtual string PlaceOfBirth { get; set; }
    }
}
