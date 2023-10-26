using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entities
{
    [Table("Adresse")]
    public class Adresse
    {
        public int Id { get; set; }
        public required int Postkode { get; set; }
        public required string Poststed { get; set; }
        public required string Gate { get; set; }
    }
}