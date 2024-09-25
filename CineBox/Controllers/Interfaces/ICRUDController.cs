using Microsoft.AspNetCore.Mvc;

namespace CineBox.Controllers.Interfaces
{
    public interface ICRUDController<TViewModel>
    {
        Task<IActionResult> Create();
        Task<IActionResult> Create(TViewModel vm);
        Task<IActionResult> Update(int id);
        Task<IActionResult> Update(TViewModel vm);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Delete(TViewModel vm);
    }
}
