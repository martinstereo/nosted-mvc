using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.Net.Http.Headers;

namespace nosted_dotnet.MVC.Models.Ordre
{
    public class OrdreViewModel
    {
        public int OrdreNummer { get; set; }
        public DateTime DatoMottatt { get; set; }
        public string? ProduktType { get; set; }
        public DateTime InnenDato { get; set; }
        public ServiceSkjemaController? ServiceSkjema { get; set; }
        public CheckListController? Sjekkliste { get; set; }
        public bool ErFerdig { get; set; }
    }
}
    
