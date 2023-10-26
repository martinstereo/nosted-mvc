using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IKundeRepository
    {
        void Upsert(Kunde kunde);
        Kunde Get(int id);
        List<Kunde> GetAll();
    }
}