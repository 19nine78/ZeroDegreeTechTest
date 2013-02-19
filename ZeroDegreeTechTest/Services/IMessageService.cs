using System;
using System.Collections.Generic;
using ZeroDegreeTechTest.Models;

namespace ZeroDegreeTechTest.Services
{
    public interface IMessageService : IDisposable
    {
        IList<Day> GetDays();
        IList<Language> GetLanguages();
        MessageOfTheDay GetMessage();
        MessageOfTheDay GetMessage(int dayId, int languageId);
    }
}
