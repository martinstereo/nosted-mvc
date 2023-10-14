using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime DateReceived { get; set; }
    public string? ProductType { get; set; }
    public DateTime TargetDate { get; set; }
    public bool IsDone { get; set; }
    public int UserId { get; set; }
    public ServiceSchema? ServiceSchema { get; set; }

    public CustomerInformation? CustomerInformation { get; set; }
    public User? User { get; set; }
}