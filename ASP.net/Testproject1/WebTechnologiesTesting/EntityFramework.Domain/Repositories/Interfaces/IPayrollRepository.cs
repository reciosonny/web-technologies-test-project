using EntityFramework.Domain.DataAccessLayer;
using EntityFramework.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Repositories {
    public interface IPayrollRepository : IRepository<Payroll> {
        decimal GetSumOfNetPay();
        decimal GetTotalDeductionsOfThePeriod(int id);
        Payroll GetItemByEmployeeId(int employeeId);
        PayrollViewModel GetPayrollDetailsOfEmployee(int employeeId);
        void AddNewPayroll(PayrollViewModel model);
        void TransferPayrollToHistory();
        IEnumerable<PayrollViewModel> SumPayrollHistoryByEmployee();
    }
}
