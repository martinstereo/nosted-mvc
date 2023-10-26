using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public interface ISjekkRepository
{
    List<Sjekk> HentAlle();
}