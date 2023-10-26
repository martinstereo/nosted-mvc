using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IProduktRepository
    {
        void Upsert(Produkt produkt);
        Produkt Get(int id);
        List<Produkt> GetAll();
    }
}