using WebApplication1.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceCoreLayer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.AppBuilder(app);
app.Run();
