using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data.Ordre;

public interface IOrdreRepository
{
    List<Entites.Ordre> HentAlle();
    int Opprett(Entites.Ordre ordre);
}