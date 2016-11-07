using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Models.Domain;
using NHibernate.Domain.Models.ViewModels;
using NHibernate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHibernate.WebApi.Controllers.API {
    public class PersonController : ApiController {

        private PersonService p = new PersonService();
        // GET api/<controller>
        public IEnumerable<Person> Get() {

            return p.GetAllPerson();
        }

        // GET api/<controller>/5
        public PersonInfoViewModel Get(int id) {
            return p.GetInfo();
            //return "value";
        }

        // POST api/<controller>
        public void Post() {
            p.AddPerson();
            //var person = new Repository<Person>();
            //person.Add(new Person() {
            //    Fname = "Sonny",
            //    Mname = "Ramirez",
            //    Lname = "Recio"
            //});
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}