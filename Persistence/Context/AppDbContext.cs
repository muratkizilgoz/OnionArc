using System;
using System.Threading;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Metadata.FindProperty("UpdatedDate") != null)
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
                }

                if (entityEntry.Metadata.FindProperty("CreatedDate") != null && entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                }

            }

            var res = await base.SaveChangesAsync();

            return res;
        }
    }
}

