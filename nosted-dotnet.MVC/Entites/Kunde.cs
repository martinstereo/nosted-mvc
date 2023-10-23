namespace nosted_dotnet.MVC.Entites;

public class Kunde
{
    public int Id { get; set; }
    public string? Navn { get; set; }
    public string? Etternavn { get; set; }
    public string? Email { get; set; }
    public string? TelefonNr { get; set; }
    
    public virtual Ordre Ordre { get; set; }
    public int OrdreId { get; set; }
    public virtual Vinsj Vinsj { get; set; }
    public int VinsjId { get; set; }
    public virtual Adresse Adresse { get; set; }
    public  int AdresseId { get; set; }
}