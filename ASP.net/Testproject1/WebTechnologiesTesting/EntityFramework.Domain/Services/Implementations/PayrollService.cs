using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Domain.UnitOfWork;
using EntityFramework.Domain.Models.ViewModels;
using EntityFramework.Domain.Services.Interfaces;
using EntityFramework.Domain.DataAccessLayer;
using System.Transactions;

namespace EntityFramework.Domain.Services {
    public class PayrollService : IPayrollService {

        private UnitOfWork.UnitOfWork uo = new UnitOfWork.UnitOfWork();

        public PayrollService() {

        }

        public IEnumerable<PayrollViewModel> SumPayrollHistoryByEmployee() {
            return uo.Payroll.SumPayrollHistoryByEmployee();
        }

        public void TransferPayrollToHistory() {

            try {
                uo.Payroll.TransferPayrollToHistory();
                uo.SaveChanges();
            }
            catch (Exception ex) {

            }
        }
        
        public void AddNewPayroll(int employeeId, decimal philhealth, decimal sss, decimal pagibig, decimal grosspay) {
            decimal netPayComputation = grosspay - (philhealth + sss + pagibig);

            try {
                using (var uow = new UnitOfWork.UnitOfWork()) {
                    var viewmodel = new PayrollViewModel() {
                        EmployeeId = employeeId,
                        GrossPay = grosspay,
                        PagIbig = pagibig,
                        SSS = sss,
                        PhilHealth = philhealth,
                        NetPay = netPayComputation
                    };
                    
                    uow.Payroll.AddNewPayroll(viewmodel);
                    uow.SaveChanges();
                }
            }
            catch(FieldAccessException ex) {

            }
            catch (EncoderFallbackException ex) {
                //todo: add logger here...
            }
            catch (Exception ex) {
                //todo: add logger here...
            }

        }

        public decimal GetTotalDeductionsOfEmployeeForThePeriod(int employeeId) {
            return uo.Payroll.GetTotalDeductionsOfThePeriod(employeeId);
        }

        public PayrollViewModel GetPayrollDetails(int employeeId) {
            //return uo.PayrollRepository.GetPayrollDetails();

            //if (logic > 2500) {

            //}
            //else {
            //    //apply different data here...
            //}


            return uo.Payroll.GetPayrollDetailsOfEmployee(employeeId);
        }
        
        public PayrollViewModel GetPayrollDetails2ndImplementation(int employeeId) {
            var e = uo.Employees.GetItem(employeeId);
            var p = uo.Payroll.GetItemByEmployeeId(employeeId);

            return new PayrollViewModel {
                EmployeeName = e.Fname + " " + e.Mname + " " + e.Lname,
                GrossPay = p.GrossPay ?? 0,
                NetPay = p.NetPay ?? 0
            };

        }
    }
}
