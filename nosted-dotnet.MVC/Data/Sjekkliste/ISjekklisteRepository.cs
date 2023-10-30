using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data;

public interface ISjekklisteRepository
{
    List<Sjekkliste> HentAlle();
    int Opprett(Sjekkliste sjekkliste);
    Sjekkliste? Hent(int id);
}