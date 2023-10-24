using nosted_dotnet.MVC.Controllers;

namespace nosted_dotnet.MVC.Models.Ordre
{
    public class OrdreRad: IEntity
    {
        public int Id { get; set; }
        public DateTime DateRecieved { get; set; }
        public string? ProductType { get; set; }
        public DateTime WithinDate { get; set; }
        public ServiceSkjemaController? ServiceSkjema { get; set; }
        public CheckListController? Sjekkliste { get; set; }
        public bool IsDone { get; set; }
    }
}
    
