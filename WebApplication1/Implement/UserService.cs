using WebApplication1.Service;

namespace WebApplication1.Implement;

public class UserService : IUserService
{
    private List<string> _data = new () { "user1", "user2" };
    
    public async Task<IEnumerable<string>> GetAllUser()
    {
        return await Task.FromResult(_data);
    }

    public async Task CreateUser(string user)
    {
        _data.Add(user);
        await Task.CompletedTask;
    }

    public async Task DeleteUser(string user)
    {
        _data.Remove(user);
        await Task.CompletedTask;
    }
}