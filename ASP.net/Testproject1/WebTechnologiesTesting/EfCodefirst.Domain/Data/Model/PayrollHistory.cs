namespace EfCodefirst.Domain.Data.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayrollHistory")]
    public partial class PayrollHistory
    {
        [Key]
        public int PayrollId { get; set; }

        public int? EmployeeId { get; set; }

        public decimal? GrossPay { get; set; }

        public decimal? SSS { get; set; }

        public decimal? Philhealth { get; set; }

        public decimal? Pagibig { get; set; }

        public decimal? NetPay { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
