using Application.Repository.Interfaces;

namespace Application.Services.Common
{
    public abstract class GenericService<TEntity, TViewModel, TRepository> 
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;

        protected GenericService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<TViewModel>> GetAllViewModels()
        {
            var entityList = await _repository.GetAllAsync();
            
            return entityList.Select(e => MapToViewModel(e)).ToList();
        }

        public virtual async Task<TViewModel> GetByIdViewModel(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return MapToViewModel(entity);
        }

        public virtual async Task Add(TViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _repository.AddAsync(entity);
        }

        public virtual async Task Update(TViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task Delete(TViewModel vm)
        {
            var entity = MapToEntity(vm);
            await _repository.DeleteAsync(entity);
        }

        protected abstract TEntity MapToEntity(TViewModel vm);
        protected abstract TViewModel MapToViewModel(TEntity entity);
    }
}
