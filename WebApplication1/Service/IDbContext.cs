using System.Data.SqlClient;
using WebApplication1.Interface;
using WebApplication1.Interface.Raw;
using WebApplication1.Interface.StoreProcedure;
using WebApplication1.Interface.Transaction;

namespace WebApplication1.Service;

public interface IDbContext : ITransaction, IDisposable, IStoreProcedureCommand, IRawCommand
{
    SqlConnection Database { get; }
    /// <summary>
    /// Represent for open connection database.
    /// </summary>
    void OpenConnection();
    /// <summary>
    /// Represent for close connection database.
    /// </summary>
    void CloseConnection();
    /// <summary>
    /// Represent for save data commit to database.
    /// </summary>
    Task SaveChangeAsync();
}