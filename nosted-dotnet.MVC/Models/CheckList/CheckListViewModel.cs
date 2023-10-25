using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Models.CheckList
{
    public class CheckListViewModel : IEntity
    {
        public int Id { get; set; }

        public string Mechanic { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal ConsumedHours { get; set; }
        public int TrykkSetting { get; set; }
        public int TrekKraft { get; set; }
        public int BremseKraft { get; set; }
        public string FunksjonsTestKommentar { get; set; }
        public string MechanicComment { get; set; }

        public int CheckListId { get; set; }
        public List<CheckListCategoryGroupModel> CategoryGroups { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipcode { get; set; }
        public string CustomerTelephoneNumber { get; set; }
        public string CustomerComment { get; set; }
        public string VinsjType { get; set; }
        public string VinsjModel { get; set; }
        public string VinsjRegNr { get; set; }
    }

    public class CheckListCategoryGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }

}