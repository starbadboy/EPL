using System.Collections.Generic;

namespace EPL.ViewModels
{
    public class TvShowViewModelCollection
    {
      public Dictionary<string, List<TvShowViewModel>> Collection { get; set; }
    }

    public class TvShowViewModel
    {
        public string VideoTitle { get; set; }
        public string Episode { get; set; }
        public string ModifiedDate { get; set; }
        public string VideoLink { get; set; }
        public int Id { get; set; }
        public string Image => "/Image/tv/"+Id+".jpg";
    }
}