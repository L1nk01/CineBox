using Application.Repository.Common;
using Database.Contexts;
using Database.Entities;

namespace Application.Repository
{
    public class GenreRepository : GenericRepository<Genre>
    {
        public GenreRepository(ApplicationContext dbContext) : base(dbContext, "Genre") { }
    }
}
