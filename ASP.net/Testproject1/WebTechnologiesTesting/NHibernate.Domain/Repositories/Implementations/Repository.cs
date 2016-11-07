using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Helpers;
using NHibernate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Repositories {

    public class Repository<T> : IRepository<T> {
        //protected ITransaction _transaction;
        protected ISession _session;
        public ISession Query
        {
            get
            {
                return _session;
            }
        }

        public Repository(ISession session) {
            _session = session; //new NHibernateHelper<T>().OpenSession();
            //_transaction = _session.BeginTransaction();
        }

        public void Add(T entity) {
            _session.Save(entity);
        }

        public T GetById(object pk) {
            return _session.Get<T>(pk);
        }

        public T Load() {
            return _session.Load<T>(typeof(T));
        }

        public IEnumerable<T> GetAll() {
            var list = _session.CreateCriteria(typeof(T)).List<T>();
            return list;
        }

        public void Remove(T entity) {
            _session.Delete(entity);
            //throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entity) {
            foreach (T item in entity) {
                _session.Delete(item);
            }
        }

        public void Update(T entity) {
            _session.Update(entity);
        }
    }
}
