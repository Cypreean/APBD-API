namespace WebApplication1.Models;

public class Animal
{
    public Animal(int id, string name, string type, string color, float weight)
    {
        Id = id;
        Name = name;
        Type = type;
        Color = color;
        Weight = weight;
    }


    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Color { get; set; }
    public float Weight { get; set; }
}