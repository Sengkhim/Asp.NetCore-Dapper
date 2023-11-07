using System.Data;
using System.Data.SqlClient;
using Dapper;
using WebApplication1.Interface.Raw;
using WebApplication1.Service;

namespace WebApplication1.Implement;

public class RawImpl : IRawAsync
{
    private readonly IDbContext _context;

    public RawImpl(IDbContext context)
        => _context = context;

    private CommandType CommandType => CommandType.Text;
    private SqlTransaction Transaction => _context.Transaction;
    private SqlConnection Db => _context.Database;

    public async Task<IEnumerable<T>> GetAllAsync<T>(string cmd)
    {
        try
        {
            var query = await Db.QueryAsync<T>(cmd, CommandType, Transaction);
            return query;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<T?> GetAsync<T>(string cmd, object target)
    {
        throw new NotImplementedException();
    }

    public Task<object?> CreateAsync(string cmd, object data)
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateAsync(string cmd, object data)
    {
        throw new NotImplementedException();
    }

    public Task<object> DeleteAsync(string cmd, object data)
    {
        throw new NotImplementedException();
    }
}