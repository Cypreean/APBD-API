namespace WebApplication1.Models;

public class Visit
{
    public int AnimalId { get; set; }
    public DateTime Date { get; set; }
    public float price { get; set; }
    public string Notes { get; set; }
    
    public Visit(int animalId, DateTime date, float price, string notes)
    {
        AnimalId = animalId;
        Date = date;
        this.price = price;
        Notes = notes;
    }
}