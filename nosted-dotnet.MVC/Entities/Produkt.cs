using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entities
{
    [Table("Produkt")]
    public class Produkt
    {
        public int Id { get; set; }
        public string? RegNr { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? Garanti { get; set; }

    }
}