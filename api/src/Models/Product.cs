using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace beauty_supplies_store.Models;

[Table("products")]
public class Product
{
    [Column("id"), Key]
    public int ID { get; set; }
    [Column("name"), Required]
    public string? Name { get; set; }
    [Column("producer"), Required]
    public string? Producer { get; set; }
    [Column("price"), Required]
    public int Price { get; set; }
    [Column("expiry_date", TypeName = "DATE")]
    public DateTime? ExpiryDate { get; set; }
}