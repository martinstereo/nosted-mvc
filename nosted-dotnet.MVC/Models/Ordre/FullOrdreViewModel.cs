

namespace nosted_dotnet.MVC.Models.Ordre
{

        // Model som skal fremvises som liste fra database
        public class FullOrdreViewModel
        {
            public FullOrdreViewModel()
            {
                UpsertModel = new OrdreViewModel();
                OrdreList = new List<OrdreViewModel>();
            }
        public OrdreViewModel UpsertModel { get; set; }
        public List<OrdreViewModel> OrdreList { get; set; }
    }
}
