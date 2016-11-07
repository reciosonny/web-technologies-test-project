using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain.Models.ViewModels {

    public class PayrollViewModel {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal PhilHealth { get; set; }
        public decimal SSS { get; set; }
        public decimal PagIbig { get; set; }

    }

}
