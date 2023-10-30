using Microsoft.EntityFrameworkCore.Metadata.Internal;
using nosted_dotnet.MVC.Enum;

namespace nosted_dotnet.MVC.Entities;

public class UtførtSjekk
{
    public int Id { get; set; }
    public int SjekklisteId { get; set; }
    public int SjekkId { get; set; }
    public  Verdi Verdi {get; set; }
    public virtual  Sjekk Sjekk { get; set; }
    public virtual Sjekkliste Sjekkliste { get; set; }
}