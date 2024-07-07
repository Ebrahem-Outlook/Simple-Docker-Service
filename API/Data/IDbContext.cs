using Microsoft.EntityFrameworkCore;

namespace API.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}