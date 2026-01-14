using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Models;

namespace Salon_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Style> Styles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
