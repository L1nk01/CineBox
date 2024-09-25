using Application.Repository.Common;
using Database.Contexts;
using Database.Entities;

namespace Application.Repository
{
    public class ProducerRepository : GenericRepository<Producer>
    {
        public ProducerRepository(ApplicationContext dbContext) : base(dbContext, "Producer") { }
    }
}
