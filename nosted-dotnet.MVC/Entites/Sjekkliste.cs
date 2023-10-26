namespace nosted_dotnet.MVC.Entites;

public class Sjekkliste
{
    public int Id { get; set; }
    public string? Kommentar { get; set; }
    public decimal? Trykk { get; set; }
    public decimal? Bremsekraft { get; set; }
    public decimal? Trekkraft { get; set; }
    public bool? VinsjTestet { get; set; }
    public virtual ICollection<UtførtSjekk> UtførteSjekker { get; set; }
    
    /*public virtual Ordre Ordre { get; set; }
    public int OrdreId { get; set; }*/
}
