using System.Data.SqlClient;
using WebApplication1.Database.Core;
namespace WebApplication1.Database;
public class DataContext : CoreDbContext
{
    public DataContext(IConfiguration configuration) : base(configuration.GetConnectionString("connection"))
    {
    }

    protected override void OnConfiguring(SqlConnection connection, SqlTransaction transaction)
    {
    }

    public override async Task SaveChangeAsync()
    {
        await Task.CompletedTask;
    }
}