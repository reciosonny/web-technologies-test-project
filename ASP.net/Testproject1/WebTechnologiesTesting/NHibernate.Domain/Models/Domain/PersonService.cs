using EntityFramework.Domain.Models.ViewModels;
using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Models.ViewModels;
using NHibernate.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Models.Domain {
    public class PersonService {

        public IEnumerable<Person> GetAllPerson() {
            var uo = new UnitOfWork();

            return uo.People.GetAll();
        }
        private UnitOfWork uow = new UnitOfWork();

        public PersonInfoViewModel GetInfo() {
            return uow.People.GetInfo();
        }


        public void AddPerson() {
            var uo = new UnitOfWork();


            uo.People.Add(new Person() {
                Fname = "Sonny",
                Mname = "Ramirez",
                Lname = "Recio"
            });
            uo.SaveChanges();

        }
    }
}
