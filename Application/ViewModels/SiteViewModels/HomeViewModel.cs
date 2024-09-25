using Application.ViewModels.Common;
using Application.ViewModels.GenreViewModels;
using Application.ViewModels.ProducerViewModels;
using Application.ViewModels.SeriesViewModels;

namespace Application.ViewModels.SiteViewModels
{
    public class HomeViewModel : GenericViewModel
    {
        public List<SeriesViewModel> Series { get; set; } = new List<SeriesViewModel>();

        public string SearchTerm { get; set; }
        public int ProducerId { get; set; }
        public int GenreId { get; set; }

        public List<ProducerViewModel> Producers { get; set; } = new List<ProducerViewModel>();
        public int? SelectedProducerId { get; set; }

        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
        public int? SelectedGenreId { get; set; }
    }
}
