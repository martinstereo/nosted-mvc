using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public class EfAdresseRepository : IAdresseRepository
    {
        private readonly DataContext _dataContext;

        public EfAdresseRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Adresse Get(int id)
        {
            return _dataContext.Adresse.FirstOrDefault(x => x.Id == id);
        }

        public List<Adresse> GetAll()
        {
            return _dataContext.Adresse.ToList();
        }

        public void Upsert(Adresse adresse)
        {
            var existing = Get(adresse.Id);
            if(existing != null)
            {
                existing.Postkode = adresse.Postkode;
                existing.Poststed = adresse.Poststed;
                existing.Gate = adresse.Gate;
                _dataContext.SaveChanges();
                return;
            }
            adresse.Id = 0;
            _dataContext.Add(adresse);
            _dataContext.SaveChanges();
        }
    }
}