using EntityFramework.Domain.Models.ViewModels;
using EntityFramework.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EntityFramework.WebApi.Controllers {
    [RoutePrefix("api/payroll")]
    public class PayrollController : ApiController {

        public PayrollController() {
            //todo: insert dependency injection here...
        }

        private PayrollService payroll = new PayrollService();
        // GET api/<controller>
        public IEnumerable<PayrollViewModel> Get() {

            var list = payroll.SumPayrollHistoryByEmployee();
            return list;
        }

        // GET api/<controller>/5
        public PayrollViewModel Get(int id) {
            return payroll.GetPayrollDetails(id);
        }

        // POST api/<controller>
        public void Post(PayrollViewModel vm) {
            payroll.AddNewPayroll(vm.EmployeeId, vm.PhilHealth, vm.SSS, vm.PagIbig, vm.GrossPay);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {

        }

        [HttpPost]
        [Route("transfertohistory")]
        public void TransferPayrollToHistory() {
            payroll.TransferPayrollToHistory();
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}