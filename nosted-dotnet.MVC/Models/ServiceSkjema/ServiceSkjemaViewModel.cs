namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    public class ServiceSkjemaViewModel
    {
        public required string Kunde { get; set; }
        //public bool IsAdministrator { get; set; }
        public required string Serienummer { get; set; }
        public DateTime MotattDato { get; set; }
        public decimal Arbeidstimer { get; set; }
        public required string ImageUrl { get; set; }
        public required string AvtaltMedKunden { get; set; }
        public required string RepBeskrivelse { get; set; }

        public required string MedgåtteDeler { get; set; }
        public required string OrdreNummer { get; set; }

        public required string KundeMail { get; set; }
        public required string KundeAdresse { get; set; }
        public  required string KundeTelefonNr { get; set; }

        public required string Produkttype { get; set; }
        public required string Årsmodell { get; set; }
        public required string ServiceRep { get; set; }

        public DateTime FerdigDato { get; set; }
        public required string UtskiftetDelerRetur { get; set; }
        public required string ForsendelsesMåte { get; set; }
        public required string SignaturKunde { get; set; }
        public required string SignaturRep { get; set; }



    }

  
}
