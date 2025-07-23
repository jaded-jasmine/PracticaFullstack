using WebApplication3.Database;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class DrinkService
    {
        private Random _random = new Random();
        private readonly DatabaseContext _context;

        public DrinkService(DatabaseContext context)
        {
            _context = context;
        }

        public List<DrinkModel> GetAll()
        {
            return _context.Drinks.ToList();
        }

        public DrinkModel GetById(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null) throw new Exception($"Drink with ID {id} not found.");
            return drink;
        }

        public void AddDrink(DrinkModel drink)
        {
            _context.Drinks.Add(drink);
            _context.SaveChanges();
        }
        public void DeleteDrink(int id)
        {
            var drinkToRemove = _context.Drinks.FirstOrDefault(d => d.Id == id);
            if (drinkToRemove != null)
            {
                _context.Drinks.Remove(drinkToRemove);
                _context.SaveChanges();
            }
        }
        public DrinkModel? FindByName(string name)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Name == name);
            if (drink == null)
            {
                throw new KeyNotFoundException($"Drink with name {name} not found.");
            }
            return drink;
        }
        public string Update(int id, string name, string description, int isAlcoholic)
        {
            var drink = _context.Drinks.Where(d => d.Id == id).FirstOrDefault();
            if (drink == null) return $"Drink with ID {id} not found.";
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description)) return "Name and/or description cannot be null.";

            drink.Name = name;
            drink.Description = description;
            drink.IsAlcoholic = isAlcoholic;

            _context.SaveChanges();

            return $"Drink with ID {id} updated successfully.";
        }
        public DrinkModel? GetRandom()
        {
            if (_context.Drinks.Count() == 0) throw new InvalidOperationException("No drinks available to select from.");
            int index = _random.Next(1, _context.Drinks.Count());
            return _context.Drinks.Skip(index).FirstOrDefault();
        }
        public List<DrinkModel> GetOdd()
        {
            return _context.Drinks.Where(d => d.Id % 2 != 0).ToList();

        }
        public List<DrinkModel> GetPages(int page, int pageSize)
        {
            if (page < 1 || pageSize < 1)
                throw new ArgumentException("Page and pageSize must be greater than 0.");
            return _context.Drinks.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
