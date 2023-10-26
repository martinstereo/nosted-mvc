using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IOrdreRepository
    {
        void Upsert(Ordre ordre);
        Ordre Get(int id);
        List<Ordre> GetAll();
    }
}