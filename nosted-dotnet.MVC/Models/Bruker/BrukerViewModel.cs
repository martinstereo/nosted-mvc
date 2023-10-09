using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.Net.Http.Headers;

namespace nosted_dotnet.MVC.Models.Bruker
{
    public class BrukerRad
    {
        public int BrukerID { get; set; }
        public string? Navn { get; set; }
        public string? Etternavn { get; set; }
        public string? Adresse { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Stilling { get; set; }
       

    }
}
    
