using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Repositories.Interfaces {
    public interface IEmployeeRepository {
        string GetFullNameOfEmployee(int id);
    }
}
