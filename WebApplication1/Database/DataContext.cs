using WebApplication1.Database.Core;
namespace WebApplication1.Database;
public class DataContext : CoreDbContext
{
    private readonly IConfiguration _configuration;
    
    public DataContext(IConfiguration configuration)
        =>  _configuration = configuration;

    protected override string ConnectionString()
        => _configuration.GetConnectionString("connection");
}