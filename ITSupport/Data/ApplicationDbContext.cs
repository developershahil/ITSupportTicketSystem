using ITSupport.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSupport.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Seed Ticket Priorities
            modelBuilder.Entity<TicketPriority>().HasData(
                new TicketPriority { PriorityId = 1, PriorityName = "Low" },
                new TicketPriority { PriorityId = 2, PriorityName = "Medium" },
                new TicketPriority { PriorityId = 3, PriorityName = "High" }
            );

            // 🔹 Seed FIRST ADMIN USER
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FullName = "System Admin",
                    Email = "admin@itsupport.com",
                    Password = "admin123",   // (hash later)
                    Role = "Admin",
                    IsActive = true
                }
            );
        }
    }
}
