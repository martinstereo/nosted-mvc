using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Customer
{
    public class CustomerInformation: IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Kunde { get; set; }

        //public bool IsAdministrator { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi serienummer.")]
        public string Serienummer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi datoen ordren ble motatt.")]
        public DateTime MotattDato { get; set; }
        public string AvtaltMedKunden { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kunde email.")]
        [EmailAddress(ErrorMessage = "Ikke en gyldig emailadresse.")]
        public string KundeMail { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundeadresse.")]
        public string KundeAdresse { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundetelefonnummer.")]
        [Phone(ErrorMessage = "Ikke et gyldig telefonnummer.")]
        public string KundeTelefonNr { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi produkttype.")]
        public string Produkttype { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi årsmodell.")]
        public string Årsmodell { get; set; }

        [Required(ErrorMessage = "Venligst fyll ut service / rep garanti.")]
        public string ServiceRep { get; set; }
    }
}
