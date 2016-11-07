using NHibernate.Criterion;
using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Models.ViewModels;
using NHibernate.Domain.Repositories.Interfaces;
using NHibernate.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Repositories {
    public class PersonRepository : Repository<Person>, IPersonRepository {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public PersonRepository(ISession session) : base(session) {}

        public PersonInfoViewModel GetInfo() {
            //var query = _session.CreateQuery("from Person as p inner join PersonInformation as pi on p.PersonInformationId=pi.PersonInformationId");
            //var query = _session.CreateQuery("from PersonInformation p");
            var query = _session.CreateCriteria<Person>("p")
                            .CreateAlias("PersonInformation", "pi")
                            .SetProjection(Projections.ProjectionList()
                                                .Add(Projections.Property("p.Fname"))
                                                .Add(Projections.Property("p.Mname"))
                                                .Add(Projections.Property("p.Lname"))
                                                .Add(Projections.Property("pi.HomeAddress")));


            IList queryList = query.List();
            foreach (var item in queryList) {
                var test = item;
            }
            return new PersonInfoViewModel();
        }

    }
}
