using System;
using Microsoft.EntityFrameworkCore;
using ServiceRequestManager.Models;

namespace ServiceRequestManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<User> Users { get; set; } // For authentication demonstration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed a user for authentication demonstration
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "testuser",
                    // In a real app, use a strong hashing algorithm like BCrypt
                    // For demo, "password123" hashed using a simple method or hardcoded for JWT.
                    // This is just a placeholder; the AuthController will check a hardcoded password.
                    PasswordHash = "hashedpasswordplaceholder"
                }
            );

            // Seed initial service request data (optional)
            modelBuilder.Entity<ServiceRequest>().HasData(
                new ServiceRequest { Id = 1, Title = "Laptop screen repair", Description = "My laptop screen is cracked.", CreatedDate = DateTime.Parse("2023-01-15T10:00:00Z"), Status = "Open", CreatedBy = "john.doe" },
                new ServiceRequest { Id = 2, Title = "Software installation", Description = "Need VS Code installed on my new machine.", CreatedDate = DateTime.Parse("2023-01-16T14:30:00Z"), Status = "In Progress", CreatedBy = "jane.smith" },
                new ServiceRequest { Id = 3, Title = "Network connectivity issue", Description = "Cannot access internal network drives.", CreatedDate = DateTime.Parse("2023-01-17T09:00:00Z"), Status = "Closed", CreatedBy = "john.doe" }
            );
        }
    }
}

