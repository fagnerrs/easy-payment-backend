using EP.Users.Domain.Models;

namespace EP.Users.Domain.Services.Interfaces;

public interface IUserService
{
    Task<long> Add(User user);
    Task<User> Get(long userId);
    Task Remove(long userId);
}