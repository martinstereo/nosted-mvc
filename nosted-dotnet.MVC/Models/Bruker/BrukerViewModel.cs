using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.Net.Http.Headers;
using nosted_dotnet.MVC.Models.Ordre;

namespace nosted_dotnet.MVC.Models.Bruker
{

    public class BrukerFullViewModel
    {
        public BrukerFullViewModel()
        {
            UpsertModel = new BrukerViewModel();
            BrukerList = new List<BrukerViewModel>();
        }
        public BrukerViewModel UpsertModel { get; set; }
        public List<BrukerViewModel> BrukerList { get; set; }


    }
    public class BrukerViewModel
    {
        public int BrukerID { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        public string Email { get; set; }
        public string? Stilling { get; set; }
    }
}
    
