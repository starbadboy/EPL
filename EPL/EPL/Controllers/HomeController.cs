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
            var viewmodels = new ScheduleService().MapToViewModel(schedules);
            return View(viewmodels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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