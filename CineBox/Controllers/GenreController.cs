using Application.Services;
using Application.ViewModels.GenreViewModels;
using Database.Contexts;
using CineBox.Controllers.Common;

namespace CineBox.Controllers
{
    public class GenreController : GenericCRUDController<GenreService, GenreViewModel>
    {
        public GenreController(ApplicationContext dbContext)
            : base(new GenreService(dbContext), "Site", "Genres")
        {
        }
    }
}
