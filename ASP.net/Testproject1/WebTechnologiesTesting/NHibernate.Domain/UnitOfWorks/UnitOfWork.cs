using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Helpers;
using NHibernate.Domain.Repositories;
using NHibernate.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.UnitOfWorks {
    public class UnitOfWork : IDisposable {
        private ISession _session;
        private ITransaction _transaction;

        public UnitOfWork() {
            _session = new NHibernateHelper().OpenSession();
            _transaction = _session.BeginTransaction();
        }

        public IProductRepository Products
        {
            get
            {
                return new ProductRepository(_session);
            }
        }
        
        public IPersonRepository People
        {
            get
            {
                return new PersonRepository(_session);
            }
        }
        
        public void SaveChanges() {

            if (_transaction == null) {
                throw new InvalidOperationException("Unit Of Work already saved");
            }

            _transaction.Commit();
        }
        
        public void Dispose() {
            //throw new NotImplementedException();
            CloseSession();
            CloseTransaction();
        }

        #region Transaction and Session Management Methods

        public void BeginTransaction() {
            _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction() {
            // _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
            _transaction.Commit();

            CloseTransaction();
        }

        public void RollbackTransaction() {
            // _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
            _transaction.Rollback();

            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction() {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession() {
            _session.Close();
            _session.Dispose();
            _session = null;
        }

        #endregion
    }
}
