using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Models.Domain;
using NHibernate.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHibernate.WebApi.Controllers.API {
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController {

        private ProductService service = new ProductService();


        // GET api/<controller>
        public IEnumerable<Product> Get() {
            return service.GetProducts();
            //return new string[] { "value1", "value2" };
        }

        [Route("bycategory/{category}")]
        public IEnumerable<Product> GetByCategory(string category) {
            return service.GetProductsByCategory(category);
        }

        [Route("byname/{name}")]
        public IEnumerable<Product> GetAllByProductName(string name) {
            return service.GetProductsByName(name);
        }

        // GET api/<controller>/5
        public string Get(int id) {
            return "value";
        }

        /// <summary>
        /// for initialization purposes only...
        /// </summary>
        [HttpPost]
        [Route("initialize")]
        public void InitializeProductTable() {
            service.InitializeProductData();
        }

        // POST api/<controller>
        public void Post(Product model) {
            service.AddNewProduct(model);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}