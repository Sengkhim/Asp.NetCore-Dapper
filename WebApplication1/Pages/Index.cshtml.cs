using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDbContext _context;
        public List<UserModel>? UserModels { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            var query = await _context.Procedure.QueryAsync<UserModel>("GetAllUsers");
            UserModels = query.Take(100).ToList();
        }
    }
}