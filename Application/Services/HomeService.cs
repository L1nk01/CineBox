using Application.ViewModels.GenreViewModels;
using Application.ViewModels.ProducerViewModels;
using Application.ViewModels.SeriesViewModels;
using Application.ViewModels.SiteViewModels;

namespace Application.Services
{
    public class HomeService
    {
        private readonly SeriesService _seriesService;
        private readonly GenreService _genreService;
        private readonly ProducerService _producerService;

        public HomeService(SeriesService seriesService, GenreService genreService, ProducerService producerService)
        {
            _seriesService = seriesService;
            _genreService = genreService;
            _producerService = producerService;
        }

        public async Task<HomeViewModel> GetHomeViewModel(string searchTerm, int? producerId, int? genreId)
        {
            var seriesViewModels = await GetSeriesViewModels(searchTerm, producerId, genreId);
            var genresViewModels = await GetGenresViewModels();
            var producersViewModels = await GetProducersViewModels();

            return new HomeViewModel
            {
                Series = seriesViewModels,
                Genres = genresViewModels,
                Producers = producersViewModels
            };
        }

        private async Task<List<SeriesViewModel>> GetSeriesViewModels(string searchTerm, int? producerId, int? genreId)
        {
            var seriesEntities = await _seriesService.GetFilteredSeries(searchTerm, producerId, genreId);
            return seriesEntities.ToList();
        }

        private async Task<List<GenreViewModel>> GetGenresViewModels()
        {
            var genresEntities = await _genreService.GetAllViewModels();
            return genresEntities.ToList();
        }

        private async Task<List<ProducerViewModel>> GetProducersViewModels()
        {
            var producersEntities = await _producerService.GetAllViewModels();
            return producersEntities.ToList();
        }
    }
}
