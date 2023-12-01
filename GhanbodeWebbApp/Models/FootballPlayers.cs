using System.ComponentModel.DataAnnotations;

namespace GhanbodeWebbApp.Models
{
    public class FootballPlayers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public string Nationality { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }
        public string Description {get; set;}
    }
}