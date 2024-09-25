using Application.ViewModels.Common;

namespace Application.ViewModels.SeriesViewModels
{
    public class SaveSeriesViewModel : GenericSeriesViewModel
    {
        public SaveSeriesViewModel()
        {
            Producers = new Dictionary<int, string>();
            Genres = new Dictionary<int, string>();
        }

        public Dictionary<int, string> Genres { get; set; }
        public Dictionary<int, string> Producers { get; set; }
    }
}
