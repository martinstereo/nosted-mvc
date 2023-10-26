using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IAdresseRepository
    {
        void Upsert(Adresse adresse);
        Adresse Get(int id);
        List<Adresse> GetAll();
    }
}