namespace WebApplication1.Interface.Raw;

public interface IRawAsync 
{
    Task<IEnumerable<T>> GetAllAsync<T>(string cmd);
    Task<T?> GetAsync<T>(string cmd, object target);
    Task<object?> CreateAsync(string cmd, object data);
    Task<object> UpdateAsync(string cmd, object data);
    Task<object> DeleteAsync(string cmd, object data);
}