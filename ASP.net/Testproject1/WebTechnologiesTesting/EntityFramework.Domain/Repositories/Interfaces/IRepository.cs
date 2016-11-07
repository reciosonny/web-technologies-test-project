using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Repositories {
    public interface IRepository<T> where T : class {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetItem(int id);
        T GetFirstItem();
        IQueryable<T> FindAllItems(Expression<Func<T, bool>> aggregate);
        //IQueryable<T> GetAllItems();
        IQueryable<T> Query { get; }
    }
}
