using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Entites;

public class Bruker
{
    public int Id { get; set; }
    public string? Fornavn { get; set; }
    public string? Etternavn { get; set; }
    public string? Email { get; set; }
    public string? TelefonNr { get; set; }
    public string? Stilling { get; set; }
    
    public virtual Adresse Adresse { get; set; }
    public  int AdresseId { get; set; }
}