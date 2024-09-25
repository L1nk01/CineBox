namespace Application.Services.Interfaces
{
    public interface IService<TViewModel>
    {
        Task<List<TViewModel>> GetAllViewModels();
        Task<TViewModel> GetByIdViewModel(int id);
        Task Add(TViewModel vm);
        Task Update(TViewModel vm);
        Task Delete(TViewModel vm);
    }
}
