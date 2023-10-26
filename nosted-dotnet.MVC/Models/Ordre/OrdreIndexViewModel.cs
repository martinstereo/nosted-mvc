namespace nosted_dotnet.MVC.Models.Ordre;

public class OrdreIndexViewModel
{
    public int OrdreId { get; set; }
    public string Fornavn { get; set; }
    public string Etternavn { get; set; }
    public string Type { get; set; }
    public string RegNr { get; set; }
    public DateTime ServiceDato { get; set; }
}