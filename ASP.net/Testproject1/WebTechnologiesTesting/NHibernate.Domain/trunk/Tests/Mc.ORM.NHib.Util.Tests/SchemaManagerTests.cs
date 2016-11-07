using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit;
using NUnit.Framework;

using NHibernate;
using NHibernate.Cfg;

using Mc.ORM.NHib.Util;

namespace Mc.ORM.NHib.Util.Tests
{
    [TestFixture]
    public class SchemaManagerTests
    {
        public string BaseDirectory { get; set; }

        [TestFixtureSetUp]
        public void SetUp()
        {
            BaseDirectory = System.Configuration.ConfigurationManager.AppSettings["BaseDirectory"];            
        }

        [Test]
        public void TestAssemlbyWithModelsCreate()
        {           
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyWithModels\bin\Debug\TestAssemblyWithModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);

            sm.Create();

            Assert.Pass();
        }

        [Test]
        public void TestAssemblyOnlyMappingsCreate()
        {            
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyMappings\bin\Debug\TestAssemblyOnlyMappings.dll" },
                ModelAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyModels\bin\Debug\TestAssemblyOnlyModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);

            sm.Create();

            Assert.Pass();
        }

        [Test]
        public void TestAssemblyWthModelsDrop()
        {
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyWithModels\bin\Debug\TestAssemblyWithModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);
            sm.Create();
            sm.Drop();

            Assert.Pass();
        }

        [Test]
        public void TestAssemblyWithModelsUpdate()
        {
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyWithModels\bin\Debug\TestAssemblyWithModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);
            sm.Create();
            sm.Update();

            Assert.Pass();
        }

        [Test]
        public void TestAssemblyOnlyMappingsDrop() 
        {
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyMappings\bin\Debug\TestAssemblyOnlyMappings.dll" },
                ModelAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyModels\bin\Debug\TestAssemblyOnlyModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);
            sm.Create();
            sm.Drop();

            Assert.Pass();
        }

        [Test]
        public void TestAssemblyOnlyMappingsUpdate()
        {
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyMappings\bin\Debug\TestAssemblyOnlyMappings.dll" },
                ModelAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyModels\bin\Debug\TestAssemblyOnlyModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);
            sm.Create();
            sm.Update();

            Assert.Pass();
        }

        [Test]
        public void TestMappingsDirectoryCreate()
        {
            var options = new SchemaManagerOptions()
            {
                Mode = SchemaManagerMode.Execute,
                MappingDirectories = new List<string>() { BaseDirectory + @"\TestData\MappingFiles" },
                ModelAssemblies = new List<string>() { BaseDirectory + @"\TestData\TestAssemblyOnlyModels\bin\Debug\TestAssemblyOnlyModels.dll" },
                ConfigFile = BaseDirectory + @"\TestData\hibernate.cfg.xml"
            };

            var sm = new SchemaManager(options);
            sm.Create();

            Assert.Pass();
        }
    }
}
