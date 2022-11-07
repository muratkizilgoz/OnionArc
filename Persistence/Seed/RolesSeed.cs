using System;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;

namespace Persistence.Seed
{
    public static class RolesSeed
    {
        public static async Task Seed(ApplicationDbContext _applicationDbContext)
        {
            if (!_applicationDbContext.Roles.Any(x => x.NormalizedName.Equals("ADMIN")))
            {
                var role = new IdentityRole { Name = "admin", NormalizedName = "ADMIN" };
                await _applicationDbContext.AddAsync(role);
                await _applicationDbContext.SaveChangesAsync();
            }

            if (!_applicationDbContext.Roles.Any(x => x.NormalizedName.Equals("USER")))
            {
                var role = new IdentityRole { Name = "user", NormalizedName = "USER" };
                await _applicationDbContext.AddAsync(role);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

