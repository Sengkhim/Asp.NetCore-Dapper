using WebApplication1.Service;

namespace WebApplication1.Implement;

public class RepositoryImpl<TModel> : IRepository<TModel> where TModel : class
{
    private readonly IDbContext _context;

    public RepositoryImpl(IDbContext context)
        => _context = context;

    public async Task<IEnumerable<TModel>> GetAllAsync()
        => await _context.Procedure.QueryAsync<TModel>("GetAllUsers");

    public Task<TModel> GetAsync(object id)
    {
        throw new NotImplementedException();
    }

    public Task<object> CreateAsync(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateAsync(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task<object> DeleteAsync(TModel model)
    {
        throw new NotImplementedException();
    }
}