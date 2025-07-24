using PracticaFullstack.Context;
using PracticaFullstack.Models;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

public class CatService
{
    private Random _random = new Random();
    private readonly DatabaseContext _context;

    public CatService(DatabaseContext context){
        _context = context;
    }


    
    public List<Cat> GetAll()
    {
        return _context.Cats.ToList();
    }

    public Cat? GetById(int id)
    {
        return _context.Cats.FirstOrDefault(cat => cat.Id == id);
    }

    
    public Cat AddCat(Cat newCat)
    {
        if (newCat.Id == 0 || _context.Cats.Any(c => c.Id == newCat.Id))
        {
            newCat.Id = _context.Cats.Any() ? _context.Cats.Max(c => c.Id) + 1 : 1;
            _context.Add(newCat);
        }
        return newCat;
    }

    public bool DeleteCat(int id)
    {
        var catToRemove = _context.Cats.FirstOrDefault(cat => cat.Id == id);

        if (catToRemove != null)
        {
            _context.Cats.Remove(catToRemove);
            return true;
        }
        return false;
    }

    public Cat? FindCat(string name)
    {
        var cat = _context.Cats.Where(c =>c.Name == name).FirstOrDefault();

        if(cat == null)
        {
            throw new Exception ($"Pisica cu numele de {name} nu a fost gasita.");
        }
        return cat;

    }

    public bool UpdateCat(Cat updatedCat)
    {
        var existingCat = _context.Cats.FirstOrDefault(c => c.Id == updatedCat.Id);

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
        if (!_context.Cats.Any())
            return null;

        int random = _random.Next(1, _context.Cats.Count());

        return _context.Cats.ElementAt(random);
    }

    public List<Cat> GetOddCat()
    {
        if(_context.Cats.Count() < 1)
        {
            throw new Exception("Lista este goala.");
        }

        return _context.Cats.Where(c => c.Id % 2 == 1).ToList();

    }

    public List<Cat> GetPages(int pageNumber, int objNumber)
    {
        return _context.Cats.Skip(objNumber * (pageNumber-1)).Take(objNumber).ToList();
    }

}


