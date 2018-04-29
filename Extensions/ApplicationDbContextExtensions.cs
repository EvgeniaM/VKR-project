using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServerVKR.Data;
using ServerVKR.Models;

namespace ServerVKR.Extensions
{
    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeeded(this ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            // SeedUsers(context, serviceProvider.GetService<IAccountManager>());
            // SeedRoles(context, roleManager);
            // SeedSuperAdmins(context, accountManager);
        }

        // private static void SeedRoles(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        // {
        //     if (!roleManager.RoleExistsAsync(ApplicationUserRoles.AdminRole).Result) {
        //         roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.AdminRole)).Wait();
        //     }
        // }

        // private static void SeedUsers(ApplicationDbContext context, IAccountManager accountManager)
        // {
        //     if (!context.Users.Any())
        //     {
        //         accountManager.CreateUserAccount("User", "test123", "70000000000", "user@user.ru").Wait();
        //     }
        // }

        // private static void SeedSuperAdmins(ApplicationDbContext context, IAccountManager accountManager)
        // {
        //     accountManager.CreateAdminAccount("Admin", "admin123", "70000000001", "admin@admin.ru").Wait();
        // }
    }
}