using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedAdminUser(builder);
    }

    private void SeedAdminUser(ModelBuilder builder)
    {
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        var adminUser = new ApplicationUser
        {
            UserName = "admin@domain.com",
            Email = "admin@domain.com",
            EmailConfirmed = true,
            // other properties...
        };

        // Hash the password instead of using plaintext
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "YourSecurePassword123");

        builder.Entity<ApplicationUser>().HasData(adminUser);
    }
}