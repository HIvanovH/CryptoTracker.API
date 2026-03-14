using CryptoTracker.Application.Common.Interfaces;
using CryptoTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>()
                .Property(a => a.TargetPrice)
                .HasPrecision(18, 8);

            modelBuilder.Entity<Asset>()
                .Property(a => a.CurrentPrice)
                .HasPrecision(18, 8);
        }
    }
}
