using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPL.DataModel;
using EPL.ViewModels;

namespace EPL.Service
{
    public class TvShowService
    {
        public TvShowViewModelCollection MapToViewModel(List<TvShow> tvshows)
        {
            List<TvShowViewModel> viewModels = tvshows.Select(tvshow => new TvShowViewModel
                {
                    VideoTitle = tvshow.Title,
                    ModifiedDate = tvshow.ModifiedOn.ToString(CultureInfo.InvariantCulture),
                    Episode = tvshow.Episode,
                    VideoLink = tvshow.Link,
                    Id = tvshow.Id
                }).ToList();
            var dict = new Dictionary<string, List<TvShowViewModel>> {["Lastest Video"] = viewModels};
            return new TvShowViewModelCollection {Collection = dict};

        }
    }
}