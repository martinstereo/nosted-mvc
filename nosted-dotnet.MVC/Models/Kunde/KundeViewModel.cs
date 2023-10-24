using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Kunde
{
    public class KundeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Navn { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kunde email.")]
        [EmailAddress(ErrorMessage = "Ikke en gyldig emailadresse.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundeadresse.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundetelefonnummer.")]
        [Phone(ErrorMessage = "Ikke et gyldig telefonnummer.")]
        public string TelefonNr { get; set; }
    }
}
