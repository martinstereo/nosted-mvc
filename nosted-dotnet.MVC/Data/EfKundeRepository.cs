using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Repositories;

namespace nosted_dotnet.MVC.Repositories
{
    public class EfKundeRepository : IKundeRepository
    {
        private readonly DataContext _dataContext;

        public EfKundeRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public Kunde Get(int id)
        {
            return _dataContext.Kunde.FirstOrDefault(x => x.Id == id);
        }

        public List<Kunde> GetAll()
        {
            return _dataContext.Kunde.ToList();
        }

        public void Upsert(Kunde kunde)
        {
            var existing = Get(kunde.Id);
            if(existing != null)
            {
                existing.Navn = kunde.Navn;
                existing.Etternavn = kunde.Etternavn;
                existing.Email = kunde.Email;
                existing.TelefonNr = kunde.TelefonNr;
                _dataContext.SaveChanges();
                return;
            }
            kunde.Id = 0;
            _dataContext.Add(kunde);
            _dataContext.SaveChanges();
        }
    }
}