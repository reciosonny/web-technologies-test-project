using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Repositories {
    public interface IRepository<T> {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        T GetById(object pk);
        T Load();
        IEnumerable<T> GetAll();
    }
}
