using EP.Shared.Infrastructure.EntityFramework;
using EP.User.Domain.Services.Interfaces;

namespace EP.User.Infrastructure.Database;

public class UserUnitOfWork : UnitOfWork<UserContext>, IUserUnitOfWork
{
    public UserUnitOfWork(UserContext context) : base(context)
    {
    }
}