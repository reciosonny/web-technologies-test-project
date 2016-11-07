namespace EfCodefirst.Domain.Data.Core {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEntities : DbContext {
        public ModelEntities()
            : base("name=ModelCodefirst") {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<PayrollHistory> PayrollHistories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.PersonId);
        }
    }
}
