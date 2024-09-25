using Application.Helpers;
using Application.Services.Interfaces;
using CineBox.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineBox.Controllers.Common
{
    public abstract class GenericCRUDController<TService, TViewModel> : Controller, ICRUDController<TViewModel>
        where TService : IService<TViewModel>
    {
        protected readonly TService _service;
        protected readonly string _redirectController;
        protected readonly string _redirectAction;

        protected GenericCRUDController(TService service, string redirectController, string redirectAction)
        {
            _service = service;
            _redirectController = redirectController;
            _redirectAction = redirectAction;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Create()
        {
            var vm = Activator.CreateInstance<TViewModel>();
            await Task.CompletedTask;

            return View("Save", vm);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            await _service.Add(vm);
            return RedirectToRoute(new { controller = _redirectController, action = _redirectAction });
        }

        [HttpGet]
        public virtual async Task<IActionResult> Update(int id)
        {
            if (!ValidationHelper.ValidateViewModelId(id))
            {
                return BadRequest("Invalid ViewModel ID.");
            }

            return View("Save", await _service.GetByIdViewModel(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Update(TViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            await _service.Update(vm);
            return RedirectToRoute(new { controller = _redirectController, action = _redirectAction });
        }

        [HttpGet]
        public virtual async Task<IActionResult> Delete(int id) => View("Delete", await _service.GetByIdViewModel(id));

        [HttpPost]
        public virtual async Task<IActionResult> Delete(TViewModel vm)
        {
            await _service.Delete(vm);
            return RedirectToRoute(new { controller = _redirectController, action = _redirectAction });
        }
    }
}
