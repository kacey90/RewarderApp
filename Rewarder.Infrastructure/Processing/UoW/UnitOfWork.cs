using Rewarder.Domain.Setup;
using Rewarder.Infrastructure.Database;

namespace Rewarder.Infrastructure.Processing.UoW;
internal class UnitOfWork : IUnitOfWork
{
    private readonly RewarderDbContext _dbContext;

    public UnitOfWork(RewarderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
