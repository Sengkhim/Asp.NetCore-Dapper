using System.Data;
using System.Data.SqlClient;
using Dapper;
using WebApplication1.Interface.StoreProcedure;
using WebApplication1.Service;

namespace WebApplication1.Implement;

public class StoreProcedureImpl : IStoreProcedureAsync
{
    private readonly IDbContext _context;

    public StoreProcedureImpl(IDbContext context)
        => _context = context;
    private  CommandType CommandType => CommandType.StoredProcedure;
    private SqlTransaction Transaction => _context.Transaction;

    public async Task<IEnumerable<T>> QueryAsync<T>(string store)
    {
        try
        {
            return await _context.Database.QueryAsync<T>(store, CommandType, Transaction);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<T?> QueryAsync<T>(string store, object target)
    {
        try
        {
            return await _context.Database.QueryFirstOrDefaultAsync<T>(store, CommandType, Transaction);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<object?> CreateAsync(string store, object data)
    {
        try
        {
            var command = await _context.Database.ExecuteAsync(store, data, Transaction,2000, CommandType);
            await _context.SaveChangeAsync();
            return command == 0 ? null : "Object has been added.";
        }
        catch (Exception e)
        {
            _context.Rollback();
            throw new Exception(e.Message);
        }
    }

    public Task<object> UpdateAsync(string store,object data)
    {
        throw new NotImplementedException();
    }

    public Task<object> DeleteAsync(string store,object data)
    {
        throw new NotImplementedException();
    }
}