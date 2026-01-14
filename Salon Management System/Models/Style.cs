using Salon_Management_System.Models;

public class Style
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
