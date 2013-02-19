using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ZeroDegreeTechTest.Models;
using NHibernate;
using ZeroDegreeTechTest.Services;

namespace ZeroDegreeTechTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Generate_Schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof (Day).Assembly);

            new SchemaExport(cfg).Execute(true,false,false);

        }
    }

    [TestClass]
    public class MessageServiceTest
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [TestInitialize]
        public void TestInit()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof (Day).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [TestMethod]
        public void Can_Get_Days()
        {
            IMessageService svc = new NHibernateService();
            svc.GetDays();
        }

    }
}
