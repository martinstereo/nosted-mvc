namespace nosted_dotnet.MVC.Entites;

public class ServiceSkjema
{
    
    public int Id { get; set; }
    public int ArbeidsTimer { get; set; }
    public string? AvtaltKunde  { get; set; }
    public string? DelerBrukt { get; set; }
    public string? DelerSkiftet { get; set; }
    public string? RepBeskrivelse { get; set; }
    public string? UtførtAv { get; set; }
    
    /*public virtual Ordre Ordre { get; set; }
    public int OrdreId { get; set; }*/
}