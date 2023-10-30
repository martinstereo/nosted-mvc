using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    public class ServiceSkjemaViewModel
    {
        //bruker data annotations for validation for hvilke krav vi har osv
        //viktig med validation for å sikre sikkerheten til applikasjonen
        [Key]
        public string ServiceSkjemaID { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Kunde { get; set; }

        //public bool IsAdministrator { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi serienummer.")]
        public string Serienummer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi datoen ordren ble motatt.")]
        public DateTime MotattDato { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi antall arbeidstimer.")]
        [Range(0, double.MaxValue, ErrorMessage = "Arbeidstimer kan ikke være et negativt tall")]
        public decimal Arbeidstimer { get; set; }

        //ikke et krav å fylle ut
        public string AvtaltMedKunden { get; set; }

        [Required(ErrorMessage = "Vennligst skriv en reparasjonsbeskrivelse.")]
        public string RepBeskrivelse { get; set; }

        [Required(ErrorMessage = "Vennligst loggfør medgåtte deler, om ingen deler skal brukes skriv det.")]
        public string MedgåtteDeler { get; set; }

        [Required(ErrorMessage = "Vennligst skriv inn ordrenummer.")]
        public string OrdreNummer { get; set; }

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

        [Required(ErrorMessage = "Vennligst oppgi ferdigstilt dato.")]
        public DateTime FerdigDato { get; set; }

        [Required(ErrorMessage = "Vennligst skriv ned utskiftet deler returnert.")]
        public string UtskiftetDelerRetur { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi forsendelsesmåte.")]
        public string ForsendelsesMåte { get; set; }

        [Required(ErrorMessage = "Kundesignatur kreves.")]
        public string SignaturKunde { get; set; }

        [Required(ErrorMessage = "Reperatørsignatur kreves.")]
        public string SignaturRep { get; set; }
    }
}