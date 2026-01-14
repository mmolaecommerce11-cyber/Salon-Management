using Salon_Management_System.Models;

namespace Salon_Management_System.Data;

public static class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.SalonServices.Any())
            return;

        context.SalonServices.AddRange(
            new SalonService
            {
                Name = "Basic Haircut",
                Category = "Men",
                Price = 120,
                DurationMinutes = 30,
                IsActive = true
            },
            new SalonService
            {
                Name = "Fade Haircut",
                Category = "Men",
                Price = 150,
                DurationMinutes = 40,
                IsActive = true
            }
        );

        context.Barbers.AddRange(
            new Barber { FullName = "John Mokoena", IsActive = true },
            new Barber { FullName = "Thabo Nkosi", IsActive = true }
        );

        context.SaveChanges();
    }
}
