using EP.Shared.Infrastructure.EntityFramework;
using EP.Users.Domain.Services.Interfaces;

namespace EP.Users.Infrastructure.Database;

public class UserUnitOfWork : UnitOfWork<UserContext>, IUserUnitOfWork
{
    public UserUnitOfWork(UserContext context) : base(context)
    {
    }
}