using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using ZeroDegreeTechTest.Models;

namespace ZeroDegreeTechTest.Services
{
    public class NHibernateService : IMessageService
    {
        private readonly ISession session;

        public NHibernateService()
        {
            session = NHibernateHelper.OpenSession();
        }


        public IList<Day> GetDays()
        {
            return session.CreateCriteria(typeof (Day)).List<Day>();
        }

        public IList<Language> GetLanguages()
        {
            return session.CreateCriteria(typeof (Language)).List<Language>();
        }

        public MessageOfTheDay GetMessage()
        {
            return GetMessage(1, 1);
        }

        public MessageOfTheDay GetMessage(int dayId, int languageId)
        {
            return session.CreateCriteria(typeof (MessageOfTheDay))
                          .Add(Restrictions.Eq("dayId", dayId))
                          .Add(Restrictions.Eq("languageId", languageId))
                          .UniqueResult<MessageOfTheDay>();
        }

        public void Dispose()
        {
            session.Close();
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
                    configuration.AddAssembly(typeof (Language).Assembly);
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