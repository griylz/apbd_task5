using Tutorial4.Models;

namespace Tutorial4.Database;

public class StaticData
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal { Id = 1, Name = "Buddy", Category = "Dog", Weight = 24.5, Color = "Brown" },
        new Animal { Id = 2, Name = "Whiskers", Category = "Cat", Weight = 5.2, Color = "Black" },
        new Animal { Id = 3, Name = "Tweet", Category = "Bird", Weight = 0.3, Color = "Yellow" }
    };
    
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit { Id = 1, AnimalId = 1, DateOfVisit = DateTime.Now, Description = "Annual Checkup", Price = 50.00M },
        new Visit { Id = 2, AnimalId = 1, DateOfVisit = DateTime.Now.AddDays(-60), Description = "Vaccination", Price = 30.00M },
        new Visit { Id = 3, AnimalId = 2, DateOfVisit = DateTime.Now.AddDays(-30), Description = "General Consultation", Price = 40.00M },
        new Visit { Id = 4, AnimalId = 2, DateOfVisit = DateTime.Now.AddDays(-10), Description = "Dental Cleaning", Price = 70.00M },
        new Visit { Id = 5, AnimalId = 3, DateOfVisit = DateTime.Now.AddDays(-5), Description = "Feather Trimming", Price = 25.00M },
        new Visit { Id = 6, AnimalId = 3, DateOfVisit = DateTime.Now.AddDays(-20), Description = "Wing Injury Treatment", Price = 100.00M }
    };
}
