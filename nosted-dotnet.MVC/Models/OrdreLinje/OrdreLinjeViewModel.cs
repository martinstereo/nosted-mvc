using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.Net.Http.Headers;

namespace nosted_dotnet.MVC.Models.ArbeidsDokument
{
    public class OrdreLinjeViewModel
    {
        public int OrdreNummer { get; set; }
        public DateTime DatoMotatt { get; set; }
        public string? ProduktType { get; set; }
        public DateTime InnenDato { get; set; }
        public ServiceSkjemaController? ServiceSkjema { get; set; }
        public CheckListController? Sjekkliste { get; set; }
        public bool ErFerdig { get; set; }
    }
}
    
