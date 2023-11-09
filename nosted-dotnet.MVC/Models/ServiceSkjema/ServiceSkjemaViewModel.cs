using System.ComponentModel.DataAnnotations;
using nosted_dotnet.MVC.Models.Ordre;

namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    
    public class ServiceSkjemaViewModel
    {
        public int Id { get; set; }
        public string AvtaltKunde { get; set; }
        public string DelerBrukt { get; set; }
        public string DelerSkiftet { get; set; }
        public string RepBeskrivelse { get; set; }
        public string UtførtAv { get; set; }
        public int ArbeidsTimer { get; set; }
        public int OrdreId { get; set; }
    }

    }