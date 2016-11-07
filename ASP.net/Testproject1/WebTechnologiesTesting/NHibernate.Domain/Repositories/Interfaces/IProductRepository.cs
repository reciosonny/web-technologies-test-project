using NHibernate.Domain.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Repositories {
    public interface IProductRepository : IRepository<Product> {
        IEnumerable<Product> GetAllProductsByCategory(string category);
        IEnumerable<Product> GetAllProductsByNameWildcard(string name);
    }
}
