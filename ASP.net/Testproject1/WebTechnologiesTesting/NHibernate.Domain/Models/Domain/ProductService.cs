using NHibernate.Domain.Data.Model;
using NHibernate.Domain.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Models.Domain {
    public class ProductService {

        private UnitOfWork uo = new UnitOfWork();

        public void AddNewProduct(Product p) {
            using (var uow = new UnitOfWork()) {
                uow.Products.Add(p);
                uow.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category) {
            return uo.Products.GetAllProductsByCategory(category);
        }

        public IEnumerable<Product> GetProductsByName(string name) {
            return uo.Products.GetAllProductsByNameWildcard(name);
        }

        public IEnumerable<Product> GetProducts() {
            return uo.Products.GetAll();
        }
        
        private readonly Product[] _products = new[] {
            new Product {Name = "Melon", Category = "Fruits"},
            new Product {Name = "Pear", Category = "Fruits"},
            new Product {Name = "Milk", Category = "Beverages"},
            new Product {Name = "Coca Cola", Category = "Beverages"},
            new Product {Name = "Pepsi Cola", Category = "Beverages"},
        };

        public void InitializeProductData() {
            //foreach (var item in _products) {
            //    uo.Products.Add(item);
            //}
            var categories = new string[] { "Fruits", "Beverages" };


            for (int i = 0; i < 1000; i++) {
                int randomCategoryAssignment = new Random().Next(0, 2);
                var model = new Product() {
                    Name = "Product" + i,
                    Category = categories[randomCategoryAssignment]
                };
                uo.Products.Add(model);
            }

            uo.SaveChanges();
        }
    }
}
