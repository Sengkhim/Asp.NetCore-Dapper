namespace WebApplication1.Interface.StoreProcedure;

public interface IStoreProcedureAsync
{
    Task<IEnumerable<T>> QueryAsync<T>(string store);
    Task<T?> QueryAsync<T>(string store, object target);
    Task<object?> CreateAsync(string store, object data);
    Task<object> UpdateAsync(string store, object data);
    Task<object> DeleteAsync(string store, object data);
}