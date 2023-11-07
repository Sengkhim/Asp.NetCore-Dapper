using WebApplication1.Database.Core;
namespace WebApplication1.Database;
public class DataContext : CoreDbContext
{
    public DataContext(IConfiguration configuration) : base(configuration.GetConnectionString("connection"))
    {
    }
}