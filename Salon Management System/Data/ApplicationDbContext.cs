using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Models;

namespace Salon_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
    public DbSet<SalonService> SalonServices => Set<SalonService>();
        public DbSet<Barber> Barbers => Set<Barber>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Payment> Payments => Set<Payment>();
    }
}