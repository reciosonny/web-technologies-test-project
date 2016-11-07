using NHibernate.Cfg;
using NHibernate.Domain.Data.Model;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Testing {
    [TestFixture]
    public class NhibernateSetupTest {

        /// <summary>
        /// Revised version of assembly loader for exporting all models into table schema
        /// Description: Creates tables in a database schema
        /// Revised by: Sonny R. Recio
        /// </summary>
        [Test]
        public void CreateSchema() {
            Assembly.Load("NHibernate.Domain"); //loads the assembly to run the dll and read its assembly information

            var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies(); //Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var assembly = referencedAssemblies.FirstOrDefault(x => x.FullName.Contains("NHibernate.Domain"));
            var classAssemblies = Helpers.GetTypesInNamespace(assembly, "NHibernate.Domain.Data.Model");

            foreach (var item in classAssemblies) {
                var cfg = new Configuration();
                cfg.Configure();
                cfg.AddAssembly(item.Assembly); //typeof(Person).Assembly
                new SchemaExport(cfg).Execute(false, true, false);
                //new SchemaExport(cfg).Create(false, true); //creates new schema
            }
        }




    }
}
