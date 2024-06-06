using beb.DbContext;
using beb.Models;
using Microsoft.EntityFrameworkCore;

namespace beb.Seed;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context.Doctors.Any() || context.Patients.Any())
            {
                return;
            }

            context.Doctors.AddRange(
                new Doctor
                {
                    FirstName = "Gregory",
                    LastName = "House",
                    Email = "dr.house@example.com"
                },
                new Doctor
                {
                    FirstName = "John",
                    LastName = "Yakuza",
                    Email = "john.yakuza@example.com"
                }
            );

            context.Patients.AddRange(
                new Patient
                {
                    FirstName = "James",
                    LastName = "Bond",
                    Birthdate = new DateTime(1995, 5, 5)
                },
                new Patient
                {
                    FirstName = "Peggy",
                    LastName = "Brown",
                    Birthdate = new DateTime(1999, 4, 21)
                }
            );

            context.Medicaments.AddRange(
                new Medicament
                {
                    Name = "1",
                    Description = "a",
                    Type = "Type1"
                },
                new Medicament
                {
                    Name = "2",
                    Description = "b",
                    Type = "Type2"
                }
            );

            context.SaveChanges();
        }
    }
}