using EntityFramework.Domain.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Domain.Models.ViewModels;

namespace EntityFramework.Domain.Repositories {
    public class PayrollRepository : GenericRepository<Payroll>, IPayrollRepository {
        
        public PayrollRepository(DbContext db) : base(db) {
            //_db = db;
        }

        public IEnumerable<PayrollViewModel> SumPayrollHistoryByEmployee() {
            var query = PayrollHistory.GroupBy(x => x.EmployeeId).Select(x => new PayrollViewModel() {
                EmployeeName = x.FirstOrDefault().Employee.Fname,
                GrossPay = x.Sum(y => y.GrossPay) ?? 0,
                NetPay = x.Sum(y => y.NetPay) ?? 0
            });

            return query.AsEnumerable();
        }

        public PayrollViewModel GetPayrollDetailsOfEmployee(int employeeId) {
            
            var query = (from p in Employees
                         join pay in Payroll on p.EmployeeId equals pay.EmployeeId
                         select new PayrollViewModel() {
                             EmployeeName = p.Fname + " " + p.Mname + " " + p.Lname,
                             GrossPay = pay.GrossPay ?? 0,
                             NetPay = pay.NetPay ?? 0
                         }).First();

            return query;
        }

        public void AddNewPayroll(PayrollViewModel model) {
            var employee = Employees.FirstOrDefault(x => x.EmployeeId == model.EmployeeId);

            var payroll = new Payroll() { Employee = employee, GrossPay = model.GrossPay, NetPay = model.NetPay, SSS = model.SSS, Pagibig = model.PagIbig, Philhealth = model.PhilHealth };

            _table.Add(payroll);
        }

        public List<PayrollViewModel> GetAllPayrollHistory() {
            var list = new List<PayrollViewModel>();

            foreach (var item in PayrollHistory) {
                list.Add(new PayrollViewModel() {
                    EmployeeName = string.Format("{0}, {1} {2}",item.Employee.Lname, item.Employee.Fname, item.Employee.Mname),
                    GrossPay = item.GrossPay??0,
                    NetPay = item.NetPay??0
                });
            }

            return list;
        }

        public void TransferPayrollToHistory() {
            foreach (var item in Payroll) {
                var payrollHistory = new PayrollHistory() { Employee = item.Employee, GrossPay = item.GrossPay, NetPay = item.NetPay, Pagibig = item.Pagibig, Philhealth = item.Philhealth, SSS = item.SSS };
                _db.Set<PayrollHistory>().Add(payrollHistory);
                _table.Remove(item);
            }
        }
        


        public Payroll GetItemByEmployeeId(int employeeId) {
            return _table.Where(x => x.EmployeeId == employeeId).First();
        }

        public decimal GetSumOfNetPay() {
            return _table.Sum(x => x.NetPay)??0;
        }

        public decimal GetTotalDeductionsOfThePeriod(int id) {
            var model = _table.Find(id);
            return model.Pagibig??0 + model.SSS??0 + model.Philhealth??0;
        }
        

        
    }
}
