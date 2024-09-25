using Application.Services;
using Application.ViewModels.ProducerViewModels;
using CineBox.Controllers.Common;
using Database.Contexts;

namespace CineBox.Controllers
{
    public class ProducerController : GenericCRUDController<ProducerService, ProducerViewModel>
    {
        public ProducerController(ApplicationContext dbContext)
            : base(new ProducerService(dbContext), "Site", "Producers")
        {
        }
    }
}
