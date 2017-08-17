using System;
using EPL.ViewModels;

namespace EPL.DataModel
{
    public class Schedule
    {
        public Schedule()
        {

        }
        public Schedule(ScheduleViewModel model)
        {
            Id = model.Id;
            HomeTeam = model.HomeTeam;
            AwayTeam = model.AwayTeam;
            Time = model.Time;
            Link = model.Link;

        }

        public int Id { get; set; }
        public int Homeid { get; set; }
        public int Awayid { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeamCn { get; set; }
        public string AwayTeamCn { get; set; }
        public DateTime Time { get; set; }
        public string Stadium { get; set; }
        public string Link { get; set; }
        public string HighLightLink { get; set; }
        public string FirstHalfLink { get; set; }
        public string SecondHalfLink { get; set; }
    }
}