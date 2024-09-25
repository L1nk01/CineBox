using Application.Repository;
using Application.ViewModels.SeriesViewModels;
using Database.Contexts;
using Database.Entities;

namespace Application.Services
{
    public class SeriesService
    {
        private readonly SeriesRepository _seriesRepository;

        public SeriesService(ApplicationContext dbContext)
        {
            _seriesRepository = new SeriesRepository(dbContext);
        }

        protected Series MapToEntity(SaveSeriesViewModel vm)
        {
            return new Series
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                ImageLink = vm.ImageLink,
                VideoLink = vm.VideoLink,
                ProducerId = vm.ProducerId,
                PrimaryGenreId = vm.PrimaryGenreId,
                SecondaryGenreId = vm.SecondaryGenreId
            };
        }

        protected SeriesViewModel MapToViewModel(Series entity)
        {
            return new SeriesViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageLink = entity.ImageLink,
                VideoLink = entity.VideoLink,
                ProducerId = entity.ProducerId,
                PrimaryGenreId = entity.PrimaryGenreId,
                SecondaryGenreId = entity.SecondaryGenreId,

                ProducerName = entity.Producer?.Name,
                PrimaryGenreName = entity.PrimaryGenre?.Name,
                SecondaryGenreName = entity.SecondaryGenre?.Name,
            };
        }

        public SaveSeriesViewModel MapToSaveViewModel(Series entity)
        {
            return new SaveSeriesViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageLink = entity.ImageLink,
                VideoLink = entity.VideoLink,
                ProducerId = entity.ProducerId,
                PrimaryGenreId = entity.PrimaryGenreId,
                SecondaryGenreId = entity.SecondaryGenreId,
            };
        }

        public async Task<SeriesViewModel> GetByIdViewModel(int id)
        {
            var entity = await _seriesRepository.GetByIdAsync(id);
            return MapToViewModel(entity);
        }

        public async Task<SaveSeriesViewModel> GetByIdSaveViewModel(int id)
        {
            var entity = await _seriesRepository.GetByIdAsync(id);
            return MapToSaveViewModel(entity);
        }

        public virtual async Task<List<SeriesViewModel>> GetAllViewModels()
        {
            var entityList = await _seriesRepository.GetAllAsync();

            return entityList.Select(e => MapToViewModel(e)).ToList();
        }

        public async Task Add(SaveSeriesViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _seriesRepository.AddAsync(entity);
        }

        public async Task Update(SaveSeriesViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _seriesRepository.UpdateAsync(entity);
        }

        public async Task Delete(SaveSeriesViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _seriesRepository.DeleteAsync(entity);
        }

        public async Task<List<Producer>> GetAllProducers()
        {
            return await _seriesRepository.GetAllProducersAsync();
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await _seriesRepository.GetAllGenresAsync();
        }

        public async Task<List<SeriesViewModel>> GetFilteredSeries(string searchTerm, int? producerId, int? genreId)
        {
            var series = await _seriesRepository.GetFilteredSeries(searchTerm, producerId, genreId);

            return series.Select(s => new SeriesViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImageLink = s.ImageLink,
                VideoLink = s.VideoLink,
                ProducerName = s.Producer.Name,
                PrimaryGenreName = s.PrimaryGenre.Name,
                SecondaryGenreName = s.SecondaryGenre?.Name,
            }).ToList();
        }
    }
}
