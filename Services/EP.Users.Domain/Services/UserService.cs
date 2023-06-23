using EP.Shared.Domain.EntityFramework;
using EP.Users.Domain.Models;
using EP.Users.Domain.Services.Interfaces;

namespace EP.Users.Domain.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> userRepository;
    private readonly IUserUnitOfWork userUnitOfWork;

    public UserService(IUserUnitOfWork userUnitOfWork)
    {
        this.userRepository = userUnitOfWork.GetGenericRepository<User>();
        this.userUnitOfWork = userUnitOfWork;
    }
    public async Task<long> Add(User user)
    {
        userRepository.Add(user);
        return await userUnitOfWork.Save();
    }

    public async Task<User> Get(long userId)
    {
        return await userRepository.GetByIdAsync(userId);
    }

    public async Task Remove(long userId)
    {
        await userRepository.Remove(userId); 
        await userUnitOfWork.Save();
    }
}

