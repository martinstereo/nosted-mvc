namespace nosted_dotnet.MVC.Entites;

public class Ordre
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime Opprettet { get; set; }
    public DateOnly ServiceDato { get; set; }
    public virtual Kunde Kunde { get; set; }
    public int KundeId { get; set; }
    public virtual Vinsj Vinsj { get; set; }
    public int VinsjId { get; set; }
        
    /*public virtual ServiceSkjema ServiceSkjema { get; set; }
    public int ServiceSkjemaId { get; set; }
    public virtual Sjekkliste Sjekkliste { get; set; }
    public int SjekklisteId { get; set; }*/
    
}
