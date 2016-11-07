using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Testing {

    [TestFixture]
    public class ProductTableTesting {


        private readonly Product[] _products = new[] {
            new Product {Name = "Melon", Category = "Fruits"},
            new Product {Name = "Pear", Category = "Fruits"},
            new Product {Name = "Milk", Category = "Beverages"},
            new Product {Name = "Coca Cola", Category = "Beverages"},
            new Product {Name = "Pepsi Cola", Category = "Beverages"},
        };

        [Test]
        public void AddProducts() {
            //var repository = new Repository<Product>();
            //foreach (var item in _products) {
            //    repository.Add(item);
            //}

            //repository.SaveChanges();

        }
    }
}
