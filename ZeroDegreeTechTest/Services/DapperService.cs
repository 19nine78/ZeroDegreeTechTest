using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using ZeroDegreeTechTest.Models;

namespace ZeroDegreeTechTest.Services
{
    public class DapperService : IMessageService
    {
        private readonly SqlConnection _dapperConn;

        public DapperService()
        {
            _dapperConn = new SqlConnection();
            _dapperConn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _dapperConn.Open();

        }

        public IList<Day> GetDays()
        {
            return _dapperConn.Query<Day>(@"SELECT [Id],[Day] as [Name] FROM [Days]").ToList();
        }

        public IList<Language> GetLanguages()
        {
            return _dapperConn.Query<Language>(@"SELECT [Id],[Language] as [Name] FROM [Languages]").ToList();
        }

        public MessageOfTheDay GetMessage()
        {
            return GetMessage(1, 1);
        }

        public MessageOfTheDay GetMessage(int dayId, int languageId)
        {
            return _dapperConn.Query<MessageOfTheDay>(@"SELECT fkDay as DayId, day, fkLanguage as languageId, [Language], message FROM MessagesByLanguageAndDay WHERE fkDay = 1 AND fkLanguage = 1").FirstOrDefault();
        }

        public void Dispose()
        {
            _dapperConn.Close();
        }

    }
}
    

    

