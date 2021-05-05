using Microsoft.EntityFrameworkCore;

namespace SportSchedule.Core.DbContexts.Contracts
{
    public interface IContextFactory<out TContext>
        where TContext : DbContext
    {
        TContext CreateContext();
    }
}