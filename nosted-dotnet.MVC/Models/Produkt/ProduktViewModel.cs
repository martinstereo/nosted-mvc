using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Produkt
{
    public class ProduktViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi en produkttype")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi årsmodell.")]
        public string AarsModell { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi serienummer.")]
        public string Serienummer { get; set; }
    }
}

