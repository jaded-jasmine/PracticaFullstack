using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("drinks")]
    public class DrinkModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IsAlcoholic { get; set; } = 0;
        public required string Description { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"DrinkModel: Id={Id}, Name={Name}, isAlcoholic={IsAlcoholic}, description={Description}";
        }
    }
}
