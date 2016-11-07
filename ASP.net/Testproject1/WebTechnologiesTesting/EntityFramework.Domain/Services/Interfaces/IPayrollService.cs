using EntityFramework.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Services.Interfaces {
    public interface IPayrollService {
        PayrollViewModel GetPayrollDetails(int employeeId);
        void AddNewPayroll(int employeeId, decimal philhealth, decimal sss, decimal pagibig, decimal grosspay);
        void TransferPayrollToHistory();
        IEnumerable<PayrollViewModel> SumPayrollHistoryByEmployee();
    }
}
