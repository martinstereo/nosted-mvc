using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data.ServiceSkjema;

public class EfServiceSkjemaRepository : IServiceSkjemaRepository
{
    private readonly DataContext _dataContext;

    public EfServiceSkjemaRepository(DataContext dataContext) 
    {
        _dataContext = dataContext;
    }
    public Entities.ServiceSkjema Get(int id)
    {
        return _dataContext.ServiceSkjema.FirstOrDefault(x => x.Id == id);
    }
    
    public Entities.ServiceSkjema GetByOrderId(int id)
    {
        return _dataContext.ServiceSkjema.FirstOrDefault(x => x.OrdreId == id);
    }

    public List<Entities.ServiceSkjema> GetAll()
    {
        return _dataContext.ServiceSkjema.ToList();
    }

    public void Upsert(Entities.ServiceSkjema serviceSkjema)
    {
        var existing = Get(serviceSkjema.Id);
        if(existing != null)
        {
            existing.ArbeidsTimer = serviceSkjema.ArbeidsTimer;
            existing.AvtaltKunde = serviceSkjema.AvtaltKunde;
            existing.DelerBrukt = serviceSkjema.DelerBrukt;
            existing.DelerSkiftet = serviceSkjema.DelerSkiftet;
            existing.RepBeskrivelse = serviceSkjema.RepBeskrivelse;
            existing.UtfortAv = serviceSkjema.UtfortAv;
            _dataContext.SaveChanges();
            return;
        }
        serviceSkjema.Id = 0;
        _dataContext.Add(serviceSkjema);
        _dataContext.SaveChanges();
    }
    
    public List<Entities.ServiceSkjema> GetAllServiceSchemas()
    {
        return _dataContext.ServiceSkjema.ToList();
    }
    
}
