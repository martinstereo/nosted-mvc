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
            return _dataContext.Sjekkliste
                .FirstOrDefault(x => x.Id == id);
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
        
    }



/*
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
    
    public List<Sjekkliste> HentAlle()
    {
        return _dataContext.Sjekkliste.ToList();
    }

    public int Opprett(Sjekkliste sjekkliste)
    { 
        _dataContext.Sjekkliste.Add(sjekkliste);
        _dataContext.SaveChanges();
        LeggTilSjekker(sjekkliste);
        return sjekkliste.Id;
    }

    public Sjekkliste? Hent(int id)
    {
        return _dataContext.Sjekkliste
            .Include(x => x.UtførteSjekker)
            .ThenInclude(x => x.Sjekk)
            .FirstOrDefault(x => x.Id == id);
    }

    private void LeggTilSjekker(Sjekkliste sjekkliste)
    {
        var nyeSjekker = _dataContext.Sjekk
            .Select(x => new UtførtSjekk
            {
                SjekkId = x.Id, 
                SjekklisteId = sjekkliste.Id
            })
            .ToList();
        
        sjekkliste.UtførteSjekker = nyeSjekker;
        _dataContext.UtførtSjekk.AddRange(nyeSjekker);
        _dataContext.SaveChanges();
    }
}
*/