namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    public class ServiceSkjemaViewModel
    {
        public string Kunde { get; set; }
        //public bool IsAdministrator { get; set; }
        public string Serienummer { get; set; }
        public DateTime MotattDato { get; set; }
        public decimal Arbeidstimer { get; set; }
        public string AvtaltMedKunden { get; set; }
        public string RepBeskrivelse { get; set; }

        public string MedgåtteDeler { get; set; }
        public string OrdreNummer { get; set; }

        public string KundeMail { get; set; }
        public string KundeAdresse { get; set; }
        public  string KundeTelefonNr { get; set; }

        public string Produkttype { get; set; }
        public string Årsmodell { get; set; }
        public string ServiceRep { get; set; }

        public DateTime FerdigDato { get; set; }
        public string UtskiftetDelerRetur { get; set; }
        public string ForsendelsesMåte { get; set; }
        public string SignaturKunde { get; set; }
        public string SignaturRep { get; set; }



    }

  
}
