namespace WebApplication1.Service;

public interface IRepository<TModel> where TModel : class
{
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<TModel> GetAsync(object id);
    Task<object> CreateAsync(TModel model);
    Task<object> UpdateAsync(TModel model);
    Task<object> DeleteAsync(TModel model);
}