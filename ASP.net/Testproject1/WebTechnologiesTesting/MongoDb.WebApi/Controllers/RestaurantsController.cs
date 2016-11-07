using MongoDb.Domain.Data.Entities;
using MongoDb.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MongoDb.WebApi.Controllers {

    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : ApiController {

        private RestaurantService restaurant = new RestaurantService();
        public RestaurantsController() {

        }
        
        [Route("{restaurantName}")]
        public IEnumerable<Restaurant> GetRestaurantByName(string restaurantName) {
            return restaurant.GetRestaurantByName(restaurantName);
        }

        // GET api/<controller>
        public IEnumerable<Restaurant> Get() {
            return restaurant.SortRestaurantListsByName();
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("findbyid/{id}")]
        public Restaurant FindById(string id) {
            return restaurant.GetById(id);
        }

        [HttpPost]
        [Route("update")]
        public void Update() {
            restaurant.Update();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public bool Delete(string id) {
            return restaurant.DeleteRestaurant(id);
        }

        // GET api/<controller>/5
        //public string Get(int id) {
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}