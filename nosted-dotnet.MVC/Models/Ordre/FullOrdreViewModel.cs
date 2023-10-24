

namespace nosted_dotnet.MVC.Models.Ordre
{
        public class OrdreFullViewModel
        {
            public OrdreFullViewModel()
            {
                UpsertModel = new OrdreViewModel();
                OrdreList = new List<OrdreViewModel>();
            }
        public OrdreViewModel UpsertModel { get; set; }
        public List<OrdreViewModel> OrdreList { get; set; }


      
    }
}
