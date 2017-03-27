using System.Collections.Generic;
using System.Linq;
using EPL.DataModel;
using EPL.ViewModels;

namespace EPL.Service
{
    public class ScheduleService
    {
        public ScheduleViewModelCollection MapToViewModel(List<Schedule> schedules)
        {
            List<ScheduleViewModel> viewModels = new List<ScheduleViewModel>();
            foreach (var schedule in schedules)
            {
                var viewmodel = new ScheduleViewModel
                {
                    Id = schedule.Id,
                    Homeid = schedule.Homeid,
                    Awayid = schedule.Awayid,
                    HomeTeam = schedule.HomeTeam,
                    AwayTeam = schedule.AwayTeam,
                    Time = schedule.Time,
                    Link = schedule.Link,
                    Stadium = schedule.Stadium
                };
                viewModels.Add(viewmodel);
            }
            var dict = viewModels.GroupBy(x => x.LongEventDate)
                             .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            return new ScheduleViewModelCollection {Collection = dict}; ;
        }
    }
}