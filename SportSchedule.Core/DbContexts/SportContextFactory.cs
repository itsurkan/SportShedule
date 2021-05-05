using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SportSchedule.Core.DbContexts.Contracts;

namespace SportSchedule.Core.DbContexts
{
    public class SportContextFactory : IContextFactory<SportContext>
    {
        private readonly DbContextOptions _options;

        public SportContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public SportContext CreateContext()
        {
            return new SportContext(_options);
        }
    }
}
