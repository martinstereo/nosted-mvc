namespace nosted_dotnet.MVC.Models.Bruker;

public class Users : IEntity
{
    public int Id { get; set; }
    public string? Navn { get; set; }
    public string? Etternavn { get; set; }
    public string? Adresse { get; set; }
    public string? Telefonnummer { get; set; }
    public string? Stilling { get; set; }
}