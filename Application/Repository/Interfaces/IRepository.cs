namespace Application.Repository.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
