using WebApplication1.Database;
using WebApplication1.Implement;
using WebApplication1.Interface.Raw;
using WebApplication1.Interface.StoreProcedure;
using WebApplication1.Service;
namespace WebApplication1.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddServiceCoreLayer(this IServiceCollection services)
    {
        services.AddTransient<IDbContext, DataContext>();
        services.AddTransient<IStoreProcedureAsync, StoreProcedureImpl>();
        services.AddTransient<IRawAsync, RawImpl>();
        return services;
    }
}