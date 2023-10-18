namespace nosted_dotnet.MVC.Models.Bruker;

public class Orders : IEntity 
{
    public int Id { get; set; }
    public DateTime DateReceived { get; set; }
    public string? ProductType { get; set; }
    public DateTime WithinDate { get; set; }
    public bool IsDone { get; set; }
    public int UserId { get; set; }
}