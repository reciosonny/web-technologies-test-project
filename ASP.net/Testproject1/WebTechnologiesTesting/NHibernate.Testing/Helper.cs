using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Testing {

    public static class Helpers {
        
        /// <summary>
        /// Basic usage: Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "**Insert namespace here...**");
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public static System.Type[] GetTypesInNamespace(Assembly assembly, string nameSpace) {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

    }

}
