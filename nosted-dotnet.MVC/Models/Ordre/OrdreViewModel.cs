using nosted_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Models.Kunde;
using nosted_dotnet.MVC.Models.Produkt;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Ordre
{   
    public class OrdreViewModel
    {
        public string OrdreID { get; set; }
        public KundeViewModel Kunde { get; set; }
        public ProduktViewModel Produkt { get; set; }

        public DateTime MottattDato { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Vennligst fyll ut service / rep garanti.")]
        public string ServiceRep { get; set; }

        public CheckListViewModel Sjekkliste { get; set; }
        public ServiceSkjemaViewModel ServiceSkjema { get; set; }
        public bool ErFerdig { get; set; } = false;
    }
}
    
