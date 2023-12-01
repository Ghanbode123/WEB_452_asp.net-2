using System.ComponentModel.DataAnnotations;
namespace GhanbodeWebbApp.Models;

public class Playstation
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public string Manufacturer { get; set; }
    public int StorageCapacityGB { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
  
}