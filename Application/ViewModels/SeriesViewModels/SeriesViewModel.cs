using Application.ViewModels.Common;

namespace Application.ViewModels.SeriesViewModels
{
    public class SeriesViewModel : GenericSeriesViewModel
    {
        // Navigation properties
        public string ProducerName { get; set; }
        public string PrimaryGenreName { get; set; }
        public string SecondaryGenreName { get; set; }
    }
}