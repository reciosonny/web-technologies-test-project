using EntityFramework.Domain.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Repositories.Implementations {
    public class Repository {
        protected DbContext _db = null; //= new NorthwindEntityFrameworkEntities();

        public Repository(DbContext db) {
            _db = db;
        }

        protected IQueryable<Employee> Employees
        {
            get
            {
                return _db.Set<Employee>();
            }
        }

        protected IQueryable<Payroll> Payroll
        {
            get
            {
                return _db.Set<Payroll>();
            }
        }

        protected IQueryable<PayrollHistory> PayrollHistory
        {
            get
            {
                return _db.Set<PayrollHistory>();
            }
        }


    }
}
