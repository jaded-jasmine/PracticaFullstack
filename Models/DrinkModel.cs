namespace WebApplication3.Models
{
    public class DrinkModel
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public bool IsAlcoholic { get; set; } = false;
        public required string Description { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"DrinkModel: Id={Id}, Name={Name}, isAlcoholic={IsAlcoholic}, description={Description}";
        }
    }
}
