using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using EPL.Repository;
using EPL.Service;

namespace EPL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new EplRepo();
            var schedules = repo.GetAllSchedule();
            DateTime gmt8time =TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                DateTime.UtcNow, "Singapore Standard Time");
            var showingschedules = schedules.Where(x => (x.Time - gmt8time).TotalHours >= -3).ToList();
            var viewmodels = new ScheduleService().MapToViewModel(showingschedules);
            return View(viewmodels);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult LinkPage(string url)
        {
            ViewBag.Message = url;
            return View();
        }
        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";
        //    var repo = new EplRepo();
        //    var schedules = repo.GetAllSchedule();
        //    var viewmodels = new ScheduleService().MapToViewModel(schedules);
        //    return View(viewmodels);
        //}


        //public ActionResult AddSchedule()
        //{
        //    ViewBag.Message = "Your Add Schedule page.";

        //    return View();
        //}
    }
}