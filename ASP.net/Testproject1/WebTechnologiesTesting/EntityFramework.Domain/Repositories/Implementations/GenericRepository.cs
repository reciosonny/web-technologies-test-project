using EntityFramework.Domain.DataAccessLayer;
using EntityFramework.Domain.Repositories;
using EntityFramework.Domain.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Repositories {

    public class GenericRepository<T> : Repository, IRepository<T>
        where T : class {

        public GenericRepository(DbContext db) : base(db) { }

        internal DbSet<T> _table
        {
            get
            {
                return _db.Set<T>();
            }
        }

        /// <summary>
        /// Gets entity tables as a whole for repository querying
        /// </summary>
        public IQueryable<T> Query
        {
            get
            {
                return _table.AsQueryable();
            }
        }

        public void Add(T entity) {
            _table.Add(entity);
            //throw new NotImplementedException();
        }

        public void Update(T entity) {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public T GetFirstItem() {
            
            return _table.First();
            //throw new NotImplementedException();
        }

        //public IQueryable<T> GetAllItems() {
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Note: 2 overloads present in where method
        /// -Expression which uses IQueryable as return value
        /// Both of them is okay, but IQueryable is much lighter as it returns SQL statement compared to IEnumerable which queries from database and store data in an object
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T GetItem(Expression<Func<T, bool>> expression) {
            return _table.Where(expression).First();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// This implementation uses IEnumerable when we get the first item. So this one queries first into the database
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T GetItem(Func<T, bool> expression) {
            return _table.Where(expression).First();
        }
        public T GetItem(int id) {
            return _table.Find(id);
            //throw new NotImplementedException();
        }

        public IQueryable<T> FindAllItems(Expression<Func<T, bool>> aggregate) {
            return _table.Where(aggregate);
            //throw new NotImplementedException();
        }

        public void Remove(T entity) {
            _table.Remove(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity) {
            _table.RemoveRange(entity);
        }
        
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "") {
            IQueryable<T> query = _table;

            if (filter != null) {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }

            if (orderBy != null) {
                return orderBy(query).ToList();
            }
            else {
                return query.ToList();
            }
        }


        /// <summary>
        /// note: SaveChanges implementation was removed in repository since we implemented Unit Of Work pattern. Noticed that we have actually 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public void SaveChanges() {
        //    _db.SaveChanges();
        //}
    }
}
