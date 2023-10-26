using nosted_dotnet.MVC.Enum;

namespace nosted_dotnet.MVC.Entites;

public class Sjekk
{
    public int Id { get; set; }
    public required string Navn { get; set; }
    public required SjekkGruppe SjekkGruppe { get; set; }

    public virtual ICollection<UtførtSjekk> UtførteSjekker { get; set; }

}