using System.ComponentModel.DataAnnotations;
namespace MvcPlaystations.Models;

    public class Playstations
{
    public int Id { get; set; }
    public string? ModelName { get; set; }
    public string? Manufacturer { get; set; }
    public int StorageCapacityGB { get; set; }
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Version { get; set; }
     public string? Colour { get; set; }
  
}

