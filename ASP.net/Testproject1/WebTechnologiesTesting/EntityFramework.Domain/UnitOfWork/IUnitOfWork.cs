using EntityFramework.Domain.DataAccessLayer;
using EntityFramework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.UnitOfWork {
    public interface IUnitOfWork {
        IRepository<Employee> Employees { get; }
        IRepository<Account> Accounts { get; }
        IPayrollRepository Payroll { get; }
        void SaveChanges();
    }
}
