using NHibernate.Domain.Data.Model;
using NHibernate.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Repositories.Interfaces {
    public interface IPersonRepository : IRepository<Person> {
        PersonInfoViewModel GetInfo();
    }
}
