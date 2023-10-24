using nosted_dotnet.MVC.Entites;
using nosted_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Models.Kunde;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Ordre
{   
    public class Ordre
    {
        public string OrdreID { get; set; }
        public KundeViewModel kunde { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi datoen ordren ble mottatt.")]
        public DateTime MottattDato { get; set; }

        [Required(ErrorMessage = "Vennligst skriv inn ordrenummer.")]
        public string OrdreNummer { get; set; }


        [Required(ErrorMessage = "Vennligst fyll ut service / rep garanti.")]
        public string ServiceRep { get; set; }
    }
}
    
