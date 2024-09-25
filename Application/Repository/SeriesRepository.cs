using Application.Repository.Common;
using Database.Contexts;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class SeriesRepository : GenericRepository<Series>
    {
        public SeriesRepository(ApplicationContext dbContext) : base(dbContext, "Series") { }

        public override async Task<Series> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Series
                .Include(s => s.Producer)
                .Include(s => s.PrimaryGenre)
                .Include(s => s.SecondaryGenre)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Series with ID {id} not found.");
            }

            return entity;
        }

        public override async Task<List<Series>> GetAllAsync()
        {
            return await _dbContext.Series
                .Include(s => s.Producer)
                .Include(s => s.PrimaryGenre)
                .Include(s => s.SecondaryGenre)
                .ToListAsync();
        }

        public async Task<List<Producer>> GetAllProducersAsync()
        {
            return await _dbContext.Producers.ToListAsync();
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<List<Series>> GetFilteredSeries(string searchTerm, int? producerId, int? genreId)
        {
            var query = _dbContext.Series
                .Include(s => s.Producer)
                .Include(s => s.PrimaryGenre)
                .Include(s => s.SecondaryGenre)
                .AsQueryable();

            // Name filter
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(s => s.Name.Contains(searchTerm));
            }

            // Producer filter
            if (producerId.HasValue)
            {
                query = query.Where(s => s.ProducerId == producerId);
            }


            if (genreId.HasValue)
            {
                query = query.Where(s => s.PrimaryGenreId == genreId || s.SecondaryGenreId == genreId);
            }

            return await query.ToListAsync();
        }
    }
}
