using System.ComponentModel.DataAnnotations.Schema;

namespace bacit_dotnet.MVC.Entities
{
    [Table("Produkt")]
    public class Produkt
    {
        public int Id { get; set; }
        public string? RegNr { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }

        //public virtual Kunde Kunde { get; set; }
        //public int KundeId { get; set; }
    }
}