using Application.Repository;
using Application.Services.Common;
using Application.Services.Interfaces;
using Application.ViewModels.GenreViewModels;
using Application.ViewModels.ProducerViewModels;
using Database.Contexts;
using Database.Entities;

namespace Application.Services
{
    public class ProducerService : GenericService<Producer, ProducerViewModel, ProducerRepository>, IService<ProducerViewModel>
    {
        public ProducerService(ApplicationContext dbContext) : base(new ProducerRepository(dbContext))
        {
        }

        protected override Producer MapToEntity(ProducerViewModel vm)
        {
            return new Producer
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                ImageLink = vm.ImageLink
            };
        }

        protected override ProducerViewModel MapToViewModel(Producer entity)
        {
            return new ProducerViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageLink = entity.ImageLink
            };
        }
    }
}
