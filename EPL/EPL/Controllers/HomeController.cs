using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using EPL.DataModel;
using EPL.Repository;
using EPL.Service;

namespace EPL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Cache.Get("schedulers") == null)
            {
                HttpContext.Cache.Insert("schedulers", GetAllSchedules(), null, DateTime.Now.AddMinutes(1),
                    Cache.NoSlidingExpiration);
            }
            var schedulers = (List<Schedule>)HttpContext.Cache.Get("schedulers");
            var showingschedules = schedulers.Where(x => (x.Time - GetGmt8TimeNow()).TotalHours >= -2).ToList();
            var viewmodels = new ScheduleService().MapToViewModel(showingschedules);
            return View(viewmodels);
        }


        public ActionResult Videos()
        {
            if (HttpContext.Cache.Get("schedulers") == null)
            {
                HttpContext.Cache.Insert("schedulers", GetAllSchedules(), null, DateTime.UtcNow.AddSeconds(30),
                    Cache.NoSlidingExpiration);
            }
            var schedulers = (List<Schedule>)HttpContext.Cache.Get("schedulers");
            var pastMatches = schedulers.Where(x => (x.Time - GetGmt8TimeNow()).TotalHours < -2).OrderByDescending(x=>x.Time).ToList();
            var viewmodels = new ScheduleService().MapToViewModel(pastMatches.Where(x=>x.Time > new DateTime(1900,1,1)).ToList());
            return View(viewmodels);
        }
        private static DateTime GetGmt8TimeNow()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                DateTime.UtcNow, "Singapore Standard Time");
        }

        private List<Schedule> GetAllSchedules()
        {
            var repo = new EplRepo();
            var schedules = repo.GetAllSchedule();
            return schedules;
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult TvShow()
        {
            var repo = new EplRepo();
            var tvshows = repo.GetAllTvShows();
            var viewmodels = new TvShowService().MapToViewModel(tvshows);
            return View(viewmodels);
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