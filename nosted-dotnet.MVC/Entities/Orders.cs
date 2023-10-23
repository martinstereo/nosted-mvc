using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Entities;

public class Orders : IEntity
{
    public int Id { get; set; }
    public DateTime DateReceived { get; set; }
    public string? ProductType { get; set; }
    public DateTime TargetDate { get; set; }
    public bool IsDone { get; set; }
    public int UserId { get; set; }
}