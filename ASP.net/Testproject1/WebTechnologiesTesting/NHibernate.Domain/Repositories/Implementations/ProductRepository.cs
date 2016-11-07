using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Domain.Data.Model;
using NHibernate.Criterion;

namespace NHibernate.Domain.Repositories {
    public class ProductRepository : Repository<Product>, IProductRepository {

        public ProductRepository(ISession session) : base(session) {
            //base._session = session;
        }

        public IEnumerable<Product> GetAllProductsByCategory(string category) {

            return _session.CreateCriteria(typeof(Product))
                .Add(Restrictions.Eq("Category", category))
                .List<Product>();
        }

        public IEnumerable<Product> GetAllProductsByNameWildcard(string name) {
            return _session.CreateCriteria(typeof(Product))
                .Add(Restrictions.Like("Name", string.Format("%{0}%", name)))
                .List<Product>();
        }

        public Product GetByName(string name) {
            return _session.CreateCriteria(typeof(Product))
                .Add(Restrictions.Eq("Name", name))
                .UniqueResult<Product>();
        }




    }
}
