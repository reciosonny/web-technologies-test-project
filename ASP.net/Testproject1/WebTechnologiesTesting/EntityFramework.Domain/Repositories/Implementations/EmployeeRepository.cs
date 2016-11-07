using EntityFramework.Domain.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Domain.Repositories.Interfaces;

namespace EntityFramework.Domain.Repositories {
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository {

        public EmployeeRepository(DbContext db) : base(db) {
            _db = db;
        }

        public string GetFullNameOfEmployee(int id) {
            var model = _table.Find(id);
            return string.Format("{0} {1}, {2}", model.Lname, model.Fname, model.Mname);
            //throw new NotImplementedException();
        }
    }
}
