using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
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
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                //if (dfi != null)
                //{
                //    Calendar cal = dfi.Calendar;

                //    if (cal.GetWeekOfYear(schedule.Time, dfi.CalendarWeekRule,
                //            dfi.FirstDayOfWeek) != cal.GetWeekOfYear(DateTime.Today.AddDays(1), dfi.CalendarWeekRule,
                //            dfi.FirstDayOfWeek)) continue;
                //}

                string[] languages = HttpContext.Current.Request.UserLanguages;
                string chosenLanguage = languages[0];
                bool isChinese = chosenLanguage.ToLower() =="zh-cn";
                var viewmodel = new ScheduleViewModel
                {
                    Id = schedule.Id,
                    Homeid = schedule.Homeid,
                    Awayid = schedule.Awayid,
                    HomeTeam = !isChinese?schedule.HomeTeam: schedule.HomeTeamCn,
                    AwayTeam = !isChinese?schedule.AwayTeam: schedule.AwayTeamCn,
                    Time = schedule.Time,
                    Link = schedule.Link,
                    Stadium = schedule.Stadium,
                    FirstHalfLink = schedule.FirstHalfLink,
                    SecondHalfLink = schedule.SecondHalfLink,
                    HighLightLink = schedule.HighLightLink
                };
                viewModels.Add(viewmodel);
            }
            var dict = viewModels.GroupBy(x => x.LongEventDate)
                             .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
            return new ScheduleViewModelCollection {Collection = dict}; 
        }
    }
}