using PracticaFullstack.Models;
using System.Reflection;

public class CatService
{
    private Random _random = new Random();
    List<Cat> context = new List<Cat>
    {
        new Cat{ Id = 1, Name = "Mittens", Age = 3, Breed = "British Shorthair"},
        new Cat{ Id = 2, Name = "Leo", Age = 6, },
        new Cat{ Id = 3, Age = 1, },
        new Cat{ Id = 4, Name = "Max", Age = 9, Breed = "Maine Coon"},
        new Cat{ Id = 5, Name = "Charlie", Age = 4},
        new Cat{ Id = 6, Age = 7},
        new Cat{ Id = 7, Name = "Jasper", Age = 5},
        new Cat{ Id = 8, Age = 2},
    };

    public CatService(){}

    public List<Cat> GetAll()
    {
        return context;
    }

    public Cat? GetById(int id)
    {
        return context.FirstOrDefault(cat => cat.Id == id);
    }

    public Cat AddCat(Cat newCat)
    {
        if (newCat.Id == 0 || context.Any(c => c.Id == newCat.Id))
        {
            newCat.Id = context.Any() ? context.Max(c => c.Id) + 1 : 1;
            context.Add(newCat);
        }
        return newCat;
    }

    public bool DeleteCat(int id)
    {
        var catToRemove = context.FirstOrDefault(cat => cat.Id == id);

        if (catToRemove != null)
        {
            context.Remove(catToRemove);
            return true;
        }
        return false;
    }

    public List<Cat> FindCat(string partialName)
    {
        if (string.IsNullOrWhiteSpace(partialName))
        {
            return new List<Cat>();
        }
        return context
            .Where(cat => cat.Name.Contains(value: partialName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool UpdateCat(Cat updatedCat)
    {
        var existingCat = context.FirstOrDefault(c => c.Id == updatedCat.Id);

        if (existingCat != null)
        {
            existingCat.Name=updatedCat.Name;
            existingCat.Age=updatedCat.Age;
            existingCat.Breed=updatedCat.Breed;
            return true;
        }

        return false;
    }

    public Cat? GetRandomCat()
    {
        if (!context.Any())
            return null;

        int random = _random.Next(1, context.Count());

        return context.ElementAt(random);
    }

}


