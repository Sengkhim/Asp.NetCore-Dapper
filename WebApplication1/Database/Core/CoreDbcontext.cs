using System.Data;
using System.Data.SqlClient;
using WebApplication1.Implement;
using WebApplication1.Interface.Raw;
using WebApplication1.Interface.StoreProcedure;
using WebApplication1.Service;
using static System.GC;

namespace WebApplication1.Database.Core;
public abstract class CoreDbContext : IDbContext
{
    private SqlConnection? _sqlConnection;
    private SqlTransaction? _sqlTransaction;
    private IStoreProcedureAsync? _storeProcedureAsync;
    private IRawAsync? _rawAsync;
    private bool _disposed;

    protected CoreDbContext(string connectionString)
        => Build(connectionString);

    /// <summary>
    /// Represent a Connection string to a database. This method child have to override.
    /// </summary>
    /// <returns></returns>
    protected virtual string ConnectionString() => "";
    
    /// <summary>
    /// Represents a connection to a SQL Server database. This class cannot be inherited.
    /// </summary>
    public SqlConnection Database => _sqlConnection!;
    
    /// <summary>
    /// Represents a Transact-SQL transaction to be made in a SQL Server database. This class cannot be inherited.
    /// </summary>
    public SqlTransaction Transaction => _sqlTransaction!;
    
    /// <summary>
    /// Represent a handle operation with store procedure option.
    /// </summary>
    public IStoreProcedureAsync Procedure => _storeProcedureAsync!;
    
    /// <summary>
    /// Represent a handle operation with SQL raw option.
    /// </summary>
    public IRawAsync Raw => _rawAsync!;

    protected virtual void OnConfiguring()
        => Build(ConnectionString());
    
    /// <summary>
    /// Represent a build database context and Opens a database connection with the property settings
    /// specified by the ConnectionString.
    /// </summary>
    /// <param name="connectionString"></param>
    private void Build(string connectionString)
    {
        _disposed = false;
        _sqlConnection = new SqlConnection(connectionString);
        OpenConnection();
        _sqlTransaction = _sqlConnection.BeginTransaction();
        _storeProcedureAsync = new StoreProcedureImpl(this);
        _rawAsync = new RawImpl(this);
    }
    
    /// <summary>
    /// Commits the database transaction.
    /// </summary>
    public virtual void Commit() =>  _sqlTransaction!.Commit();
    
    /// <summary>
    /// Rolls back a transaction from a pending state.
    /// </summary>
    public virtual void Rollback() =>  _sqlTransaction!.Rollback();
    
    /// <summary>
    /// Asynchronously commits the database transaction.
    /// </summary>
    public virtual async Task SaveChangeAsync()
        =>  await _sqlTransaction!.CommitAsync();
    
    /// <summary>
    /// Opens a database connection with the property settings specified by the ConnectionString.
    /// </summary>
    public virtual void OpenConnection()
    {
        if (_sqlConnection!.State != ConnectionState.Open)
            _sqlConnection.Open();
    }
    
    /// <summary>
    /// Closes and Dispose the connection to the database. This is the preferred method of closing any open connection.
    /// </summary>
    public virtual void CloseConnection()
    {
        if (_sqlConnection!.State == ConnectionState.Closed) return;
        _sqlConnection.Close();
        _sqlConnection.Dispose();
        _sqlTransaction!.Dispose();
    }
    
    public void Dispose()
    {
        Dispose(true);
        SuppressFinalize(this);
    }
    
    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
            CloseConnection();
        _disposed = true;
    }
}