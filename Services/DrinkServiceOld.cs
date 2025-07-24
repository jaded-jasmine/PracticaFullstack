public class DrinkService
{
    private List<DrinkModel> drinks = new List<DrinkModel>
    {
        new DrinkModel(1, "Water", "Refreshing and hydrating"),
        new DrinkModel(2, "Coffee", "A hot beverage made from roasted coffee beans"),
        new DrinkModel(3, "Tea", "A hot or cold beverage made by steeping tea leaves"),
        new DrinkModel(4, "Juice", "A drink made from the extraction of fruits or vegetables"),
        new DrinkModel(5, "Soda", "A carbonated soft drink"),
        new DrinkModel(6, "Beer", "An alcoholic beverage made from fermented grains"),
        new DrinkModel(7, "Wine", "An alcoholic beverage made from fermented grapes"),
        new DrinkModel { Id = 8, Name = "Lemonade", Description = "A refreshing drink made from lemons, sugar, and water", IsAlcoholic=false }
	};

	public DrinkService() { 
        
    }

    public List<DrinkModel> GetAll()
    {
        return drinks;
    }

    public string GetById(int id)
    {
		var drink = drinks.FirstOrDefault(d => d.Id == id);
		if (drink == null) return $"Drink with ID {id} not found.";
		return drink.ToString();
	}

    public void AddDrink(DrinkModel drink)
    {
        drinks.Add(drink);
	}
    public void DeleteDrink(int id)
    {
        var drinkToRemove = drinks.FirstOrDefault(d => d.Id == id);
        if (drinkToRemove == null) throw new KeyNotFoundException($"Drink with ID {id} not found.");
		drinks.Remove(drinkToRemove); 
	}
    public DrinkModel FindByName(string name)
    {
        var drink = drinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		if (drink == null) 
        {
            throw new KeyNotFoundException($"Drink with ID {id} not found.");
		}
        return drink;
	}
    public string Update(int id, string name, string description, bool isAlcoholic)
    {
        var drink = drinks.FirstOrDefault(d => d.Id == id);
        if (drink == null) return $"Drink with ID {id} not found.";
        if(name == null || description == null) return "Name and/or description cannot be null.";

		drink.Name = name;
        drink.Description = description;
        drink.IsAlcoholic = isAlcoholic;
		return $"Drink with ID {id} updated successfully.";
	}
}