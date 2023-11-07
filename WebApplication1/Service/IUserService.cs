namespace WebApplication1.Service;

public interface IUserService
{
    Task<IEnumerable<string>> GetAllUser();
    Task CreateUser(string user);
    Task DeleteUser(string user);
}