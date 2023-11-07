namespace WebApplication1.Extension;

public static class ApplicationCollectionExtension
{
    public static void AppBuilder(this IApplicationBuilder application, IEndpointRouteBuilder endpoints)
    {
        application.UseHttpsRedirection();
        application.UseStaticFiles();
        application.UseRouting();
        application.UseAuthorization();
        endpoints.MapRazorPages();
        endpoints.MapControllers();
    }
}