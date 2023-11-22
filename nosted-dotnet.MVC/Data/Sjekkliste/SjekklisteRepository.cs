using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data;

public class SjekklisteRepository : ISjekklisteRepository
{
    private readonly DataContext _dataContext;

    public SjekklisteRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        
    }
        public Sjekkliste Get(int id)
        {
            return _dataContext.Sjekkliste.FirstOrDefault(x => x.Id == id);
        }
        
        public Sjekkliste GetByOrderId(int id)
        {
            return _dataContext.Sjekkliste.FirstOrDefault(x => x.OrdreId == id);
        }
        
        public void Create(Sjekkliste sjekkliste)
        {
            if (sjekkliste == null)
            {
                throw new ArgumentNullException(nameof(sjekkliste));
            }

            _dataContext.Sjekkliste.Add(sjekkliste);
            _dataContext.SaveChanges();
        }

        public void Update(Sjekkliste sjekkliste)
        {
            if (sjekkliste == null)
            {
                throw new ArgumentNullException(nameof(sjekkliste));
            }

            _dataContext.Entry(sjekkliste).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
        
        public void Upsert(Sjekkliste sjekkliste)
        {
            if (sjekkliste == null)
            {
                throw new ArgumentNullException(nameof(sjekkliste));
            }

            if (sjekkliste.Id == 0)
            {
                _dataContext.Sjekkliste.Add(sjekkliste);
            }
            else
            {
                _dataContext.Entry(sjekkliste).State = EntityState.Modified;
            }

            _dataContext.SaveChanges();
        }
        
        public List<Sjekkliste> GetAllSjekklister()
        {
            // henter alle sjekkliste entities fra databasen
            return _dataContext.Sjekkliste.ToList();
        }
        
    }