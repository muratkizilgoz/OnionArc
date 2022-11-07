using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Seed
{
    public static class UsersSeed
    {
        public static async Task Seed(ApplicationDbContext _applicationDbContext)
        {
            var userStore = new UserStore(_applicationDbContext);

            if (!_applicationDbContext.Users.Any(x => x.NormalizedUserName.Equals("MURAT@MURAT.COM")))
            {
                var user = new ApplicationUser
                {
                    FirstName = "Murat",
                    LastName = "Kizilgoz",
                    NormalizedUserName = "MURAT@MURAT.COM",
                    NormalizedEmail = "MURAT@MURAT.COM",
                    EmailConfirmed = true,
                    Email = "murat@murat.com",
                    UserName = "murat@murat.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow

                };

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin123.");


                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "ADMIN");
                await userStore.AddToRoleAsync(user, "USER");
                await userStore.Context.SaveChangesAsync();

            }
            if (!_applicationDbContext.Users.Any(x => x.NormalizedUserName.Equals("USER@USER.COM")))
            {
                var user = new ApplicationUser
                {
                    FirstName = "User",
                    LastName = "UserLastName",
                    NormalizedUserName = "USER@USER.COM",
                    NormalizedEmail = "USER@USER.COM",
                    EmailConfirmed = true,
                    Email = "user@user.com",
                    UserName = "user@user.com",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow

                };

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "User123.");


                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "USER");
                await userStore.Context.SaveChangesAsync();
            }
        }
    }
}

