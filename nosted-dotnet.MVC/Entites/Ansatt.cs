namespace nosted_dotnet.MVC.Entites;

public class Ansatt
{
    public int Id { get; set; }
    public string? Navn { get; set; }
    public string? Etternavn { get; set; }
    public string? Email { get; set; }
    public string? TelefonNr { get; set; }
    public string? Stilling { get; set; }
    
    public virtual Adresse Adresse { get; set; }
    public  int AdresseId { get; set; }
}