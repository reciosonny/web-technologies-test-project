using EntityFramework.Domain.DataAccessLayer;
using EntityFramework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.UnitOfWork {
    /// <summary>
    ///Note: If Dependency Injection containers are used like StructureMap, there may be no need to implement Unit of Work
    ///Summary: This Unit of Work pattern is based from Microsoft's sample implementation for Entity Framework 5 located here: 
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork {
        /// <summary>
        /// This object serves as the Unit Of Work. The intention here is to have the same DbContext across different Repositories
        /// </summary>
        private NorthwindEntityFrameworkEntities context = new NorthwindEntityFrameworkEntities();
        public UnitOfWork() {

        }

        public IRepository<Employee> Employees {
            get {
                return new GenericRepository<Employee>(context);
            }
        }

        public IRepository<Account> Accounts {
            get {
                return new GenericRepository<Account>(context);
            }
        }

        public IPayrollRepository Payroll {
            get {
                return new PayrollRepository(context);
            }
        }

        public void SaveChanges() {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
