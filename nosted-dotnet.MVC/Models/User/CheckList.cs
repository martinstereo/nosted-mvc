using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Models.Bruker;

public class CheckList : IEntity
{
    public int Id { get; set; }
    public string Mechanic { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal ConsumedHours { get; set; }
    public string MechanicComment { get; set; }
    public int CheckListId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerStreet { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerZipcode { get; set; }
    public string CustomerTelephoneNumber { get; set; }
    public string CustomerComment { get; set; }
    public string VinsjType { get; set; }
    public string VinsjModel { get; set; }

    public int UserId { get; set; }

    public List<ChecklistCategory> ChecklistCategories { get; set; } 
}