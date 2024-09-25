using Application.Repository;
using Application.Services.Common;
using Application.Services.Interfaces;
using Application.ViewModels.GenreViewModels;
using Database.Contexts;
using Database.Entities;

namespace Application.Services
{
    public class GenreService : GenericService<Genre, GenreViewModel, GenreRepository>, IService<GenreViewModel>
    {
        public GenreService(ApplicationContext dbContext) : base(new GenreRepository(dbContext))
        {
        }

        protected override Genre MapToEntity(GenreViewModel vm)
        {
            return new Genre
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                ImageLink = vm.ImageLink
            };
        }

        protected override GenreViewModel MapToViewModel(Genre entity)
        {
            return new GenreViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageLink = entity.ImageLink
            };
        }
    }
}
