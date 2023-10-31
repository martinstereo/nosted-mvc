using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public class EfOrdreRepository : IOrdreRepository
    {
        private readonly DataContext _dataContext;

        public EfOrdreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Ordre Get(int id)
        {
            return _dataContext.Ordre.FirstOrDefault(x => x.Id == id);
        }

        public List<Ordre> GetAll()
        {
            return _dataContext.Ordre.ToList();
        }

        public void Upsert(Ordre ordre)
        {
            var existing = Get(ordre.Id);
            if (existing != null)
            {
                existing.ServiceDato = ordre.ServiceDato;
                existing.ServiceRep = ordre.ServiceRep;
                _dataContext.SaveChanges();
                return;
            }

            ordre.Id = 0;
            _dataContext.Add(ordre);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var ordreToDelete = Get(id);
            if (ordreToDelete != null)
            {
                _dataContext.Ordre.Remove(ordreToDelete);
                _dataContext.SaveChanges();
            }
        }
    }
}