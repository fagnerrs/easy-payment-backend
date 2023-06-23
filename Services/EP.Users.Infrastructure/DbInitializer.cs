using EP.Users.Infrastructure.Database;

namespace EP.Users.Infrastructure;

public class DbInitializer
{
        private readonly UserContext context;

        public DbInitializer(UserContext context)
        {
            this.context = context;
        }

        public void Run()
        {
            context.Database.EnsureCreated();
        }
}