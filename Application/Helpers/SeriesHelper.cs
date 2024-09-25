using Application.Services;
using Application.ViewModels.SeriesViewModels;

namespace Application.Helpers
{
    public static class SeriesHelper
    {
        public static async Task PopulateProducersAndGenres(SaveSeriesViewModel vm, SeriesService seriesService)
        {
            var producers = await seriesService.GetAllProducers();
            var genres = await seriesService.GetAllGenres();

            vm.Producers = producers.ToDictionary(p => p.Id, p => p.Name);
            vm.Genres = genres.ToDictionary(g => g.Id, g => g.Name);
        }
    }
}