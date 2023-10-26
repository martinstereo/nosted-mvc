using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public class EfProduktRepository : IProduktRepository
    {
        private readonly DataContext _dataContext;

        public EfProduktRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Produkt Get(int id)
        {
            return _dataContext.Produkt.FirstOrDefault(x => x.Id == id);
        }

        public List<Produkt> GetAll()
        {
            return _dataContext.Produkt.ToList();
        }

        public void Upsert(Produkt produkt)
        {
            var existing = Get(produkt.Id);
            if(existing != null)
            {
                existing.RegNr = produkt.RegNr;
                existing.Model = produkt.Model;
                existing.Type = produkt.Type;
                _dataContext.SaveChanges();
                return;
            }
            produkt.Id = 0;
            _dataContext.Add(produkt);
            _dataContext.SaveChanges();
        }
    }
}