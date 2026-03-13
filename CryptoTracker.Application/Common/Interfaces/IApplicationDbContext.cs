using CryptoTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Asset> Assets { get; }

        DbSet<User> Users { get; }

        DbSet<Alert> Alerts { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
