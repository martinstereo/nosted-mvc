namespace nosted_dotnet.MVC.Entites;

public class Vinsj
{
    public int Id { get; set; }
    public int RegNr { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }

    public virtual Kunde Kunde { get; set; }
    public int KundeId { get; set; }
}