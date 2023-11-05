using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data;

public interface ISjekklisteRepository
{
    public Sjekkliste Get(int id);
    public void Create(Sjekkliste sjekkliste);
    public void Update(Sjekkliste sjekkliste);
    public void Upsert(Sjekkliste sjekkliste);

    public Sjekkliste GetByOrderId(int id);
}


/*
public interface ISjekklisteRepository
{
    List<Sjekkliste> HentAlle();
    int Opprett(Sjekkliste sjekkliste);
    Sjekkliste? Hent(int id);
}
*/