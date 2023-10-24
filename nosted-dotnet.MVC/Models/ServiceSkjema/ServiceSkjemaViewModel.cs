using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    public class ServiceSkjemaViewModel: IEntity
    {
        //bruker data annotations for validation for hvilke krav vi har osv
        //viktig med validation for å sikre sikkerheten til applikasjonen
        public int Id { get; set; }
        public int UserId { get; set; }


        [Required(ErrorMessage = "Vennligst skriv en reparasjonsbeskrivelse.")]
        public string RepBeskrivelse { get; set; }

        [Required(ErrorMessage = "Vennligst loggfør medgåtte deler, om ingen deler skal brukes skriv det.")]
        public string MedgåtteDeler { get; set; }

        [Required(ErrorMessage = "Vennligst skriv inn ordrenummer.")]
        public string OrdreNummer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi antall arbeidstimer.")]
        [Range(0, double.MaxValue, ErrorMessage = "Arbeidstimer kan ikke være et negativt tall")]
        public decimal Arbeidstimer { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi ferdigstilt dato.")]
        public DateTime FerdigDato { get; set; }

        [Required(ErrorMessage = "Vennligst skriv ned utskiftet deler returnert.")]
        public string UtskiftetDelerRetur { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi forsendelsesmåte.")]
        public string ForsendelsesMåte { get; set; }

        //[Required(ErrorMessage = "Kundesignatur kreves.")]
        //public string SignaturKunde { get; set; }

        [Required(ErrorMessage = "Reperatørsignatur kreves.")]
        public string SignaturRep { get; set; }
        
}
}