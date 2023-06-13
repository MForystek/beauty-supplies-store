namespace beauty_supplies_store.Models;

public class Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public DateTime ExpiryDate { get; set; }
}