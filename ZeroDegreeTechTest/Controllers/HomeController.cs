using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroDegreeTechTest.Services;

namespace ZeroDegreeTechTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController()
        {
            _messageService = new NHibernateService();
        }
        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            var days =_messageService.GetDays();
            var lang = _messageService.GetLanguages();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
