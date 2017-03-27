using System.Threading.Tasks;
using System.Web.Mvc;
using EPL.DataModel;
using EPL.Repository;
using EPL.ViewModels;

namespace EPL.Controllers
{
    public class ScheduleController : Controller
    {
        public ScheduleController()
        {
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSchedule(ScheduleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var schedule = new Schedule(model);
                var repo = new EplRepo();
                repo.UpSertSchedule(schedule);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("About", "Home");
        }

     
    }
}