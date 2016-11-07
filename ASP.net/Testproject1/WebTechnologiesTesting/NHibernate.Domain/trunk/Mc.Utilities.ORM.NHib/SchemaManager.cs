//  David Newman <newman.de@gmail.com>
//
// Copyright (C) 2010 David Newman
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Reflection;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Mc.ORM.NHib.Util
{
    /// <summary>
    /// Wraps the SchemaExport and SchemaUpdate tools from NHibernate, providing a
    /// single easy to use class to manage database schemas.
    /// </summary>
    public class SchemaManager
    {

        /// <summary>
        /// Stores assemblies for future resolution
        /// </summary>
        private Dictionary<string, Assembly> AssemblyCache { get; set; }

        /// <summary>
        /// Initialized ISessionFactory
        /// </summary>
        /// 
        private ISessionFactory _sessionFactory = null;
        protected ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    if (Configuration == null)
                        throw new ArgumentException("Could not create ISessionFactory because there is no Configuration");

                    _sessionFactory = Configuration.BuildSessionFactory();
                }

                return _sessionFactory;
            }
            set { _sessionFactory = value; }
        }


        /// <summary>
        /// NHibernate Congfiguration
        /// </summary>
        protected Configuration Configuration { get; set; }

        /// <summary>
        /// Options that drive how schema is exported or updated
        /// </summary>
        protected SchemaManagerOptions Options { get; set; }

        /// <summary>
        /// Initializes a new SchemaManager instance
        /// </summary>
        /// <param name="config">NHibernate configuration</param>
        /// <param name="options">Options that drive how schema is exported or updated</param>
        public SchemaManager(SchemaManagerOptions options)
        {
            Configuration = new Configuration();
            Configuration.Configure(options.ConfigFile);
            Configuration.SetProperty("proxyfactory.factory_class", typeof(FakeProxyFactoryFactory).AssemblyQualifiedName);
            Options = options;

            AssemblyCache = new Dictionary<string, Assembly>();

            if (options.ModelAssemblies != null && options.ModelAssemblies.Any())
                AddModelsToDomain();

            if (options.MappingAssemblies != null && options.MappingAssemblies.Any())
                AddAssemblyMappings();

            if (options.MappingDirectories != null && options.MappingDirectories.Any())
                AddMappingsFromDirectories();
        }

        /// <summary>
        /// If Options.Mode is Execute then this method will generate the correct DDL script
        /// and execute it against the database.  If Options.Mode is Silent then this method
        /// will only generate the correct DDL script.
        /// </summary>
        /// <returns>string containing the DDL script for updating the schema</returns>
        public string Update()
        {            
            var sqlText = new StringBuilder();

            try
            {
                SchemaUpdate updater = null;
                if (Options.Settings != null)
                {
                    updater = new SchemaUpdate(Configuration, Options.Settings);
                }
                else
                {
                    updater = new SchemaUpdate(Configuration);
                }

                Action<string> lineAction = line => sqlText.AppendLine(line);

                using (var session = SessionFactory.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        switch (Options.Mode)
                        {
                            case SchemaManagerMode.Execute:
                                updater.Execute(lineAction, true);
                                break;
                            case SchemaManagerMode.Silent:
                                updater.Execute(lineAction, false);
                                break;
                            default:
                                throw new InvalidOperationException("The value of SchemaManager.Options.Mode is unknown");
                        }
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SchemaManagerException("Error updating schema: " + ex.Message, sqlText.ToString(), ex);
            }

            return sqlText.ToString();
        }

        /// <summary>
        /// Drops the schema from the database
        /// </summary>
        /// <returns>DDL script for dropping the schema</returns>
        public string Drop()
        {
            var sqlText = new StringBuilder();

            try
            {
                var schema = new SchemaExport(Configuration);

                using (var session = SessionFactory.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        Action<string> lineAction = line => sqlText.AppendLine(line);

                        switch (Options.Mode)
                        {
                            case SchemaManagerMode.Execute:
                                schema.Execute(lineAction, true, true);
                                break;

                            case SchemaManagerMode.Silent:
                                schema.Execute(lineAction, false, true);
                                break;

                            default:
                                throw new InvalidOperationException("The value of SchemaManager.Options.Mode is unknown");
                        }

                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SchemaManagerException("Error dropping schema: " + ex.Message, sqlText.ToString(), ex);
            }

            return sqlText.ToString();
        }

        /// <summary>
        /// Creates the schema in the database
        /// </summary>
        /// <returns>DDL script used to create the schema</returns>
        public string Create()
        {
            var sqlText = new StringBuilder();

            try
            {
                var schema = new SchemaExport(Configuration);

                using (var session = SessionFactory.OpenSession())
                {
                    using (var trans = session.BeginTransaction())
                    {
                        Action<string> lineAction = line => sqlText.AppendLine(line);

                        switch (Options.Mode)
                        {
                            case SchemaManagerMode.Execute:
                                schema.Execute(lineAction, true, false);
                                break;

                            case SchemaManagerMode.Silent:
                                schema.Execute(lineAction, false, false);
                                break;

                            default:
                                throw new InvalidOperationException("The value of SchemaManager.Options.Mode is unknown");
                        }

                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new SchemaManagerException("Error creating schema: " + ex.Message, sqlText.ToString(), ex);
            }

            return sqlText.ToString();
        }

        /// <summary>
        /// Adds mappings embedded in a set of assemblies to the configuration
        /// </summary>
        protected void AddAssemblyMappings()
        {
            try
            {
                System.AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                foreach (var asm in Options.MappingAssemblies)
                {
                    var mappings = Assembly.LoadFrom(asm);
                    AssemblyCache[mappings.FullName] = mappings;
                    AssemblyCache[mappings.GetName().Name] = mappings;

                    Configuration.AddAssembly(mappings);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                System.AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            }
        }

        protected Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (AssemblyCache.ContainsKey(args.Name))
                return AssemblyCache[args.Name];

            return null;
        }

        protected void AddMappingsFromDirectories()
        {
            try
            {
                System.AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                foreach (var dir in Options.MappingDirectories)
                {
                    Configuration.AddDirectory(new System.IO.DirectoryInfo(dir));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                System.AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            }
        }

        /// <summary>
        /// Adds any model classes to the app domain
        /// </summary>
        protected void AddModelsToDomain()
        {
            foreach (var asm in Options.ModelAssemblies)
            {
                var models = Assembly.LoadFrom(asm);
                AssemblyCache[models.FullName] = models;
                AssemblyCache[models.GetName().Name] = models;
            }
        }

    }
}
