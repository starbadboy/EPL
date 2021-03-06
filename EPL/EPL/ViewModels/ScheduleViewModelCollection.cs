using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPL.ViewModels
{
    public class ScheduleViewModelCollection
    {
        public Dictionary<string,List<ScheduleViewModel>> Collection{ get; set; }
    }

    public class ScheduleViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "HomeId")]
        public int Homeid { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AwayId")]
        public int Awayid { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "HomeTeam")]
        public string HomeTeam { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "AwayTeam")]
        public string AwayTeam { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public DateTime Time { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Stadium")]
        public string Stadium { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Link")]
        public string Link { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "HighLightLink")]
        public string HighLightLink { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "FirstHalfLink")]
        public string FirstHalfLink { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "SecondHalfLink")]
        public string SecondHalfLink { get; set; }

        public string KickOffTimeWithOutDate => Time.ToString("HH:mm");
        public string LongEventDate => Time.DayOfWeek+" " + Time.ToString("MMMM dd, yyyy");
        public string ShortEventDate => Time.ToString("ddd dd MMM yyyy");
    }
}