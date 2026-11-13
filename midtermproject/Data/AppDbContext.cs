using Microsoft.EntityFrameworkCore;
using midtermproject.Models;

namespace midtermproject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Anna Carolina",
                    Email = "Easyset24@Gmail.Com",
                    Password = "password123",
                    DateOfBirth = "1998-05-14",
                    Bio = "Frequent traveler and designer.",
                    Disability = "None",
                    AccessibilityNeeds = null,
                    Gender = "Female",
                    MobileNumber = "+995 555 12 34 56",
                    EmergencyContact = null,
                    Address = "Tbilisi, Georgia"
                },
                new User
                {
                    Id = 2,
                    FullName = "Giorgi Beridze",
                    Email = "giorgi@easyset24.com",
                    Password = "user2pass",
                    DateOfBirth = "2001-09-22",
                    Bio = "Software engineering student.",
                    Disability = "None",
                    AccessibilityNeeds = "Wheelchair access",
                    Gender = "Male",
                    MobileNumber = "+995 599 98 76 54",
                    EmergencyContact = "+995 577 11 22 33",
                    Address = "Batumi, Georgia"
                }
            );
        }
    }
}

