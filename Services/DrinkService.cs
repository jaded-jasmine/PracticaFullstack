using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class DrinkService
    {
        private List<DrinkModel> _drinks = new List<DrinkModel>
        {
            new DrinkModel {Id = 1, Name = "Coca Cola", IsAlcoholic = false, Description = "A popular soft drink."},
            new DrinkModel {Id = 2, Name = "Pepsi", IsAlcoholic = false, Description = "A well-known cola beverage."},
            new DrinkModel {Id = 3, Name = "Orange Juice", IsAlcoholic = false, Description = "Freshly squeezed orange juice."},
            new DrinkModel {Id = 4, Name = "Lemonade", IsAlcoholic = false, Description = "A refreshing drink made from lemons, sugar, and water"},
            new DrinkModel {Id = 5, Name = "Iced Tea", IsAlcoholic = false, Description = "A chilled tea beverage."},
            new DrinkModel {Id = 6, Name = "Beer", IsAlcoholic = true, Description = "An alcoholic beverage made from fermented grains."},
            new DrinkModel {Id = 7, Name = "Wine", IsAlcoholic = true, Description = "An alcoholic beverage made from fermented grapes."},
            new DrinkModel {Id = 8, Name = "Water", IsAlcoholic = false, Description = "Essential for life, hydrating and refreshing."}

        };

        public DrinkService()
        {

        }

        public List<DrinkModel> GetAll()
        {
            return _drinks;
        }

        public DrinkModel GetById(int id)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null) throw new Exception($"Drink with ID {id} not found.");
            return drink;
        }

        public void AddDrink(DrinkModel drink)
        {
            _drinks.Add(drink);
        }
        public void DeleteDrink(int id)
        {
            var drinkToRemove = _drinks.FirstOrDefault(d => d.Id == id);
            if (drinkToRemove != null)
                _drinks.Remove(drinkToRemove);
        }
        public DrinkModel FindByName(string name)
        {
            var drink = _drinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (drink == null)
            {
                throw new KeyNotFoundException($"Drink with name {name} not found.");
            }
            return drink;
        }
        public string Update(int id, string name, string description, bool isAlcoholic)
        {
            var drink = _drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null) return $"Drink with ID {id} not found.";
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description)) return "Name and/or description cannot be null.";

            drink.Name = name;
            drink.Description = description;
            drink.IsAlcoholic = isAlcoholic;

            return $"Drink with ID {id} updated successfully.";
        }
        public DrinkModel GetRandom()
        {
            if (_drinks.Count == 0) throw new InvalidOperationException("No drinks available to select from.");
            Random random = new Random();
            int index = random.Next(_drinks.Count);
            return _drinks[index];
        }
    }
}
