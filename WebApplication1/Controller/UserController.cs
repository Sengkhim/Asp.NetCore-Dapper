using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Request;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/")]
public class UserController : ControllerBase
{
    private readonly IDbContext _context;

    public UserController(IDbContext context)
        => _context = context;

    [HttpGet("get-user")]
    public async Task<IActionResult> GetUserStoreAsync() 
        => Ok(await _context.Procedure.QueryAsync<UserModel>("GetAllUsers"));
    
    [HttpGet("get-raw-user")]
    public async Task<IActionResult> GetUserRawAsync() 
        => Ok(await _context.Raw.GetAllAsync<UserModel>("SELECT * FROM dbo.Users"));

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUserAsync()
    {
        for (int i = 0; i < 1000000; i++)
        {
            var request = new UserRequest($"Username{i}", $"Password{i}", $"Gmail{i}");
            await _context.Procedure.CreateAsync("AddUser", request);
        }
        await _context.Transaction.CommitAsync();
        return Ok();
    }
}