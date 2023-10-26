using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entities
{
    [Table("Kunde")]
    public class Kunde
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public string? Etternavn { get; set; }
        public string? Email { get; set; }
        public string? TelefonNr { get; set; }


        //public virtual Produkt Produkt { get; set; }
        //public int ProduktId { get; set; }
        public virtual Adresse Adresse { get; set; }
        public int AdresseId { get; set; }
    }
}