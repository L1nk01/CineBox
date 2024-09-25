using Application.Helpers;
using Application.Services;
using Application.ViewModels.SeriesViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CineBox.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;

        public SeriesController(ApplicationContext dbContext)
        {
            _seriesService = new SeriesService(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (!ValidationHelper.ValidateViewModelId(id))
            {
                return BadRequest("Invalid ViewModel ID.");
            }

            var vm = await _seriesService.GetByIdSaveViewModel(id);

            await SeriesHelper.PopulateProducersAndGenres(vm, _seriesService);

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveSeriesViewModel vm)
        {
            // I know this is a bad practice, along with almost everything I have built around the SeriesViewModel
            // but I weren't able to think of anything better and I don't have much time to turn this asignment in :/.
            // Hopefully in the next assignment I will find out a better way.
            //ModelState.Remove(nameof(vm.ProducerName));
            //ModelState.Remove(nameof(vm.PrimaryGenreName));
            //ModelState.Remove(nameof(vm.SecondaryGenreName));

            if (!ModelState.IsValid)
            {
                await SeriesHelper.PopulateProducersAndGenres(vm, _seriesService);
                return View("Save", vm);
            }

            await _seriesService.Update(vm);
            return RedirectToRoute(new { controller = "Site", action = "Series" });
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            var vm = new SaveSeriesViewModel();

            await SeriesHelper.PopulateProducersAndGenres(vm, _seriesService);

            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSeriesViewModel vm)
        {
            //ModelState.Remove(nameof(vm.ProducerName));
            //ModelState.Remove(nameof(vm.PrimaryGenreName));
            //ModelState.Remove(nameof(vm.SecondaryGenreName));

            if (!ModelState.IsValid)
            {
                await SeriesHelper.PopulateProducersAndGenres(vm, _seriesService);
                return View("Save", vm);
            }

            await _seriesService.Add(vm);
            return RedirectToRoute(new { controller = "Site", action = "Series" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _seriesService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveSeriesViewModel vm)
        {
            await _seriesService.Delete(vm);
            return RedirectToRoute(new { controller = "Site", action = "Series" });
        }

        [HttpGet]
        public async Task<IActionResult> Watch(int id)
        {
            if (!ValidationHelper.ValidateViewModelId(id))
            {
                return BadRequest("Invalid ViewModel ID.");
            }

            return View(await _seriesService.GetByIdViewModel(id));
        }
    }
}
