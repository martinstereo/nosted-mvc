using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Ordre
{
    public class OrdreRad
    {
        public int OrderID { get; set; }
        public DateTime DateRecieved { get; set; }
        public OrdreSkjema OrdreSkjema { get; set; } = new OrdreSkjema();
        public string? ProductType { get; set; }
        public DateTime WithinDate { get; set; }
        public ServiceSkjemaViewModel? ServiceSkjema { get; set; }
        public CheckListViewModel? Sjekkliste { get; set; }
        public bool IsDone { get; set; }
    }
   
    public class OrdreSkjema
    {
        //trenger vi OrdreskjemaID her? 
        public string OrdreSkjemaID { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Etternavn { get; set; }
        //public bool IsAdministrator { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi serienummer.")]
        public string Serienummer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi datoen ordren ble mottatt.")]
        public DateTime MottattDato { get; set; }
        [Required(ErrorMessage = "Vennligst skriv inn ordrenummer.")]
        public string OrdreNummer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kunde email.")]
        [EmailAddress(ErrorMessage = "Ikke en gyldig emailadresse.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundeadresse.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundetelefonnummer.")]
        [Phone(ErrorMessage = "Ikke et gyldig telefonnummer.")]
        public string TelefonNr { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi produkttype.")]
        public string Produkttype { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi årsmodell.")]
        public string Årsmodell { get; set; }

        [Required(ErrorMessage = "Vennligst fyll ut service / rep garanti.")]
        public string ServiceRep { get; set; }
    }
}
    
