using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Domain.Helpers {
    public class NHibernateHelper {
        private ISessionFactory _sessionFactory;
        
        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null) {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("NHibernate.Domain");
                    //configuration.AddAssembly(typeof(T).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        
        public ISession OpenSession() {
            return SessionFactory.OpenSession();
        }
    }
}
