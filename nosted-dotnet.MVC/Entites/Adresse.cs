namespace nosted_dotnet.MVC.Entites;

public class Adresse
{
    public int Id { get; set; }
    public required int Postkode { get; set; }
    public required string Adressen { get; set; }
    public required int Husnummer { get; set; }

    public virtual List<Kunde> Kunder { get; set; }
    public virtual List<Ansatt> Ansatte { get; set; }
}