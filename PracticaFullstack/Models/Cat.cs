namespace PracticaFullstack.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age{ get; set; }
        public string? Breed { get; set; }
    }

    public class Category
    {
        public int Id { get; set; } 
        public required string Name { get; set; }

        public ICollection<Cat> Products { get; set; } = new List<Cat>();

    }
}
