using System.Data.SqlClient;

namespace WebApplication1.Interface.Transaction;

public interface ITransaction
{
    /// <summary>
    /// Represents a Transact-SQL transaction to be made in a SQL Server database. This class cannot be inherited.
    /// </summary>
    SqlTransaction Transaction { get; }
    /// <summary>
    /// Represent for handle a commit the data to database.
    /// </summary>
    void Commit();
    /// <summary>
    /// Represent for handle the roll back if have some problem when interaction with database.
    /// </summary>
    void Rollback();
}