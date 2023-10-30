using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data;

public interface ISjekkRepository
{
    List<Sjekk> HentAlle();
}