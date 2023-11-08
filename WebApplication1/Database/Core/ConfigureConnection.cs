using System.Data.SqlClient;

namespace WebApplication1.Database.Core;

/// <summary>
/// Represent a configure connection with core data context.
/// </summary>
public delegate void ConfigureConnectionDelegate(SqlConnection connection, SqlTransaction transaction);
