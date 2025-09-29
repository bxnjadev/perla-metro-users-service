using perla_metro_users_service.Model;
using perla_metro_users_service.Util;

namespace perla_metro_users_service.Data.Seeder;

public class SeedData 
{
    
    public static void Initialize(ApplicationDbContext context,
        IEncryptStrategy encryptStrategy)
    {
        if (context.Users.Any())
            return;

        Console.WriteLine("Realizando migración...");
        
        var password1 = "ehwasdh$sjsD__";
        var password2 = "rrr%sdjd__Djd";
        
        context.Users.AddRange(
            new User()
            {
                Name = "David",
                Email = "david.araya@perlmetro.cl",
                Date = "28/09/2025",
                LastNames = "Araya",
                Password = encryptStrategy.Encrypt(password1),
                IsActive = true
            },
            new User() 
            {
                Name = "Matías",
                Email = "matias.salas@perlmetro.cl",
                Date = "28/09/2025",
                LastNames = "Salas",
                Password = encryptStrategy.Encrypt(password2),
                IsActive = true
            }
        );

        context.SaveChanges();
    }

    
    
}