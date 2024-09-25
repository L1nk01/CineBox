using CineBox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.Services;
using Database.Contexts;
using Application.ViewModels.SiteViewModels;

namespace CineBox.Controllers
{
    public class SiteController : Controller
    {
        private readonly GenreService _genreService;
        private readonly ProducerService _producerService;
        private readonly SeriesService _seriesService;
        private readonly HomeService _homeService;

        public SiteController(ApplicationContext dbContext)
        {
            _genreService = new GenreService(dbContext);
            _producerService = new ProducerService(dbContext);
            _seriesService = new SeriesService(dbContext);
            _homeService = new HomeService(_seriesService, _genreService, _producerService);
        }

        public async Task<IActionResult> Home(string searchTerm, int? producerId, int? genreId)
        {
            var homeViewModel = await _homeService.GetHomeViewModel(searchTerm, producerId, genreId);
            return View(homeViewModel);
        }

        public async Task<IActionResult> Series()
        {
            return View(await _seriesService.GetAllViewModels());
        }

        public async Task<IActionResult> Genres()
        {
            return View(await _genreService.GetAllViewModels());
        }

        public async Task<IActionResult> Producers()
        {
            return View(await _producerService.GetAllViewModels());
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
