using EntityFramework.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Domain.DataAccessLayer;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EntityFramework.Domain.Repositories.Implementations {
    public class AccountRepository : Repository, IAccountRepository {
        public AccountRepository(DbContext db) : base(db) {}

        public void GetAccountDetails() {
            var test = (from s in Employees select s);
        }

    }
}
