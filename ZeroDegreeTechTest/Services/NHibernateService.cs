using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using ZeroDegreeTechTest.Models;

namespace ZeroDegreeTechTest.Services
{
    public class NHibernateService : IMessageService
    {
        public IList<Models.Day> GetDays()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(Day)).List<Day>();
            }
        }

        public IList<Models.Language> GetLanguages()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(Language)).List<Language>();
            }
        }

        public Models.MessageOfTheDay GetMessage()
        {
            throw new NotImplementedException();
        }

        public Models.MessageOfTheDay GetMessage(int dayId, int languageId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory sessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Language).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}